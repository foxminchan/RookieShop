using Marten;
using Microsoft.Extensions.Logging;
using RookieShop.Infrastructure.Email.Smtp.Abstractions;

namespace RookieShop.Infrastructure.Email.Smtp.Decorator;

public sealed class SmtpOutboxDecorator(
    ISmtpService smtpService,
    ILogger<SmtpOutboxDecorator> logger,
    IDocumentSession session) : ISmtpService
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

        session.Store(emailOutbox);

        await session.SaveChangesAsync(cancellationToken);

        try
        {
            await smtpService.SendEmailAsync(emailMetadata, cancellationToken);
            emailOutbox.IsSent = true;
        }
        catch(Exception ex)
        {
            logger.LogError(ex, "[{Service}] Failed to send email to {To} with subject {Subject}",
                nameof(SmtpOutboxDecorator), emailMetadata.To, emailMetadata.Subject);
        }
        finally
        {
            session.Update(emailOutbox);
            await session.SaveChangesAsync(cancellationToken);
        }
    }
}