using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RookieShop.Infrastructure.HostedServices;
using RookieShop.Persistence;

namespace RookieShop.Application.Workers;

public sealed class CalculateRatingWorker : CronJobBackgroundService
{
    private readonly ILogger<CalculateRatingWorker> _logger;
    private readonly IServiceProvider _serviceProvider;

    public CalculateRatingWorker(ILogger<CalculateRatingWorker> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        Cron = "0 0 0 * * ?"; // Run at midnight
    }

    protected override async Task DoWork(CancellationToken stoppingToken)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            _logger.LogInformation("[{Worker}] Calculate rating worker running at: {Time}",
                nameof(CalculateRatingWorker),
                DateTimeOffset.Now);

            var productRatings = await dbContext.Feedbacks
                .GroupBy(f => f.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    AverageRating = g.Average(f => f.Rating),
                    TotalReviews = g.Count()
                })
                .ToListAsync(stoppingToken);

            foreach (var rating in productRatings)
            {
                var product = await dbContext.Products.FindAsync([rating.ProductId], stoppingToken);

                if (product is null) continue;

                product.AverageRating = rating.AverageRating;

                product.TotalReviews = rating.TotalReviews;

                dbContext.Products.Update(product);
            }

            await dbContext.SaveChangesAsync(stoppingToken);

            _logger.LogInformation("[{Worker}] Calculate rating worker completed at: {Time}",
                nameof(CalculateRatingWorker),
                DateTimeOffset.Now);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "[{Worker}] Calculate rating worker failed at: {Time}", nameof(CalculateRatingWorker),
                DateTimeOffset.Now);
        }
    }
}