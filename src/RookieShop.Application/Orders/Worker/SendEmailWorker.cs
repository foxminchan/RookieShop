using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RookieShop.Domain.Entities.OrderAggregator.IntegrationEvents;
using RookieShop.Infrastructure.Bus.InMemory.Internal;
using RookieShop.Infrastructure.Email.Smtp;
using RookieShop.Infrastructure.Email.Smtp.Abstractions;

namespace RookieShop.Application.Orders.Worker;

public sealed class SendEmailWorker(
    InMemoryMessageQueue queue,
    ISmtpService smtpService,
    ILogger<SendEmailWorker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var @event in queue.Reader.ReadAllAsync(stoppingToken))
        {
            if (@event is not OrderInvoiceIntegrationEvent<EmailMetadata> sendEmailIntegrationEvent)
                continue;

            logger.LogInformation("[{Event}] Sending email to {Email}",
                nameof(OrderInvoiceIntegrationEvent<EmailMetadata>), sendEmailIntegrationEvent.Metadata.To);

            await smtpService.SendEmailAsync(sendEmailIntegrationEvent.Metadata, stoppingToken);

            logger.LogInformation("[{Event}] Email sent to {Email}",
                nameof(OrderInvoiceIntegrationEvent<EmailMetadata>), sendEmailIntegrationEvent.Metadata.To);
        }
    }
}