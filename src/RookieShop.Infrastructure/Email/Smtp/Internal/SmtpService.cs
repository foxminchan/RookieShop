using FluentEmail.Core;
using Polly;
using Polly.Retry;
using RookieShop.Infrastructure.Email.Smtp.Abstractions;

namespace RookieShop.Infrastructure.Email.Smtp.Internal;

public sealed class SmtpService<T>(IFluentEmailFactory fluentEmailFactory) : ISmtpService<T>
    where T : notnull
{
    private readonly AsyncRetryPolicy _policy = Policy.Handle<Exception>()
        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

    public async Task SendEmailAsync(EmailMetadata<T> emailMetadata, CancellationToken cancellationToken = default)
    {
        var email = fluentEmailFactory.Create();

        email = email
            .To(emailMetadata.To)
            .Subject(emailMetadata.Subject)
            .UsingTemplate(emailMetadata.Template, emailMetadata.Model);

        if (!string.IsNullOrWhiteSpace(emailMetadata.Bcc)) email = email.BCC(emailMetadata.Bcc);

        if (!string.IsNullOrWhiteSpace(emailMetadata.Cc)) email = email.CC(emailMetadata.Cc);

        await _policy.ExecuteAsync(async token => await email.SendAsync(token), cancellationToken);
    }
}