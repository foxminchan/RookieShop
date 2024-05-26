using Microsoft.Extensions.Logging;
using RookieShop.Infrastructure.Cache.Redis;
using RookieShop.Infrastructure.Email.Smtp.Abstractions;

namespace RookieShop.Infrastructure.Email.Smtp.Decorator;

public sealed class SmtpOutboxDecorator(
    ISmtpService smtpService,
    ILogger<SmtpOutboxDecorator> logger,
    IRedisService redisService) : ISmtpService
{
    public async Task SendEmailAsync(EmailMetadata emailMetadata, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{Service}] Sending email to {To} with subject {Subject}",
            nameof(SmtpOutboxDecorator), emailMetadata.To, emailMetadata.Subject);

        var emailOutbox = new EmailOutbox
        {
            Body = emailMetadata.Body,
            Subject = emailMetadata.Subject,
            To = emailMetadata.To,
            Cc = emailMetadata.Cc,
            Bcc = emailMetadata.Bcc,
            IsSent = false
        };

        await redisService.GetOrSetAsync(emailOutbox.Id.ToString(), () => emailOutbox, TimeSpan.FromDays(1));

        await smtpService.SendEmailAsync(emailMetadata, cancellationToken);

        await redisService.RemoveAsync(emailOutbox.Id.ToString());
    }
}