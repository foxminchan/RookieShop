using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RookieShop.Infrastructure.HostedServices;
using RookieShop.Persistence;

namespace RookieShop.Application.Products.Workers;

public sealed class CalculateRatingWorker : CronJobBackgroundService
{
    private readonly ILogger<CalculateRatingWorker> _logger;
    private readonly IServiceProvider _serviceProvider;

    public CalculateRatingWorker(ILogger<CalculateRatingWorker> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        Cron = "0 0 0 * * ?"; // Run at midnight
        // Cron = "0 */1 * * * ?"; // Run every minute
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

            var allProductIds = await dbContext.Products
                .Select(p => p.Id)
                .ToListAsync(stoppingToken);

            foreach (var productId in allProductIds)
            {
                var productRating =
                    productRatings.Find(r => r.ProductId == productId);

                var product =
                    await dbContext.Products.FindAsync([productId, stoppingToken], cancellationToken: stoppingToken);

                if (product is null) continue;

                product.AverageRating = productRating?.AverageRating ?? 0;

                product.TotalReviews = productRating?.TotalReviews ?? 0;

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