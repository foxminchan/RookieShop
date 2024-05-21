using Microsoft.Extensions.Hosting;
using Quartz;

namespace RookieShop.Infrastructure.HostedServices;

public abstract class CronJobBackgroundService : BackgroundService
{
    protected string Cron { get; set; } = string.Empty;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var cron = new CronExpression(Cron);
        var next = cron.GetNextValidTimeAfter(DateTimeOffset.Now);

        while (!stoppingToken.IsCancellationRequested)
        {
            if (next.HasValue && DateTimeOffset.Now >= next)
            {
                await DoWork(stoppingToken);

                next = cron.GetNextValidTimeAfter(DateTimeOffset.Now);
            }

            var delay = next.HasValue ? (int)(next.Value - DateTimeOffset.Now).TotalMilliseconds : 5000;
            await Task.Delay(Math.Max(1, delay), stoppingToken);
        }
    }

    protected abstract Task DoWork(CancellationToken stoppingToken);
}