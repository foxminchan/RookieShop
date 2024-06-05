using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RookieShop.Infrastructure.HostedServices;
using RookieShop.Persistence;

namespace RookieShop.Application.Products.Workers;

public sealed class CalculateRatingWorker : CronJobBackgroundService
{
    private readonly ILogger<CalculateRatingWorker> _logger;
    private readonly IServiceProvider _serviceProvider;

    public CalculateRatingWorker(ILogger<CalculateRatingWorker> logger, IServiceProvider serviceProvider,
        IHostEnvironment environment)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        Cron = environment.IsDevelopment() ? "0 */1 * * * ?" : "0 0 0 * * ?";
    }

    protected override async Task DoWork(CancellationToken stoppingToken)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var feedbacks = await dbContext.Feedbacks
                .GroupBy(feedback => feedback.ProductId)
                .Select(group => new
                {
                    ProductId = group.Key,
                    AverageRating = group.Average(feedback => feedback.Rating),
                    TotalFeedback = group.Count()
                })
                .ToListAsync(stoppingToken);

            foreach (var feedback in feedbacks)
            {
                var product = await dbContext.Products
                    .IgnoreAutoIncludes()
                    .Where(product => !product.IsDeleted)
                    .FirstOrDefaultAsync(product => product.Id == feedback.ProductId, stoppingToken);

                if (product is null) continue;

                product.UpdateRating(feedback.AverageRating, feedback.TotalFeedback);

                dbContext.Products.Update(product);
            }

            _logger.LogInformation("[{Worker}] Calculate rating worker running at: {Time}",
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