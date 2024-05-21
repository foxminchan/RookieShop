using Marten;
using Microsoft.Extensions.Logging;
using RookieShop.Infrastructure.Email.Smtp.Abstractions;

namespace RookieShop.Infrastructure.Email.Smtp.Decorator;

public sealed class SmtpOutboxDecorator(
    ISmtpService smtpService,
    ILogger<SmtpOutboxDecorator> logger,
    IDocumentSession documentSession) : ISmtpService
{
    public async Task SendEmailAsync(EmailMetadata emailMetadata, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("[{Service}] Sending email to {To} with subject {Subject}",
            nameof(SmtpOutboxDecorator), emailMetadata.To, emailMetadata.Subject);

        var emailOutbox = new EmailOutbox
        {
            Model = emailMetadata.Model,
            Subject = emailMetadata.Subject,
            Template = emailMetadata.Template,
            To = emailMetadata.To,
            Cc = emailMetadata.Cc,
            Bcc = emailMetadata.Bcc,
            IsSent = false
        };

        documentSession.Store(emailOutbox);

        await documentSession.SaveChangesAsync(cancellationToken);

        await smtpService.SendEmailAsync(emailMetadata, cancellationToken);

        emailOutbox.IsSent = true;

        documentSession.Update(emailOutbox);

        await documentSession.SaveChangesAsync(cancellationToken);
    }
}