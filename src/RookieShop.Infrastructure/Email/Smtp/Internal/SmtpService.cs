using FluentEmail.Core;
using Polly.Registry;
using RookieShop.Infrastructure.Email.Smtp.Abstractions;

namespace RookieShop.Infrastructure.Email.Smtp.Internal;

public sealed class SmtpService<T>(
    IFluentEmailFactory fluentEmailFactory,
    ResiliencePipelineProvider<string> pipelineProvider) : ISmtpService<T>
    where T : notnull
{
    public async Task SendEmailAsync(EmailMetadata<T> emailMetadata, CancellationToken cancellationToken = default)
    {
        var email = fluentEmailFactory.Create();

        email = email
            .To(emailMetadata.To)
            .Subject(emailMetadata.Subject)
            .UsingTemplate(emailMetadata.Template, emailMetadata.Model);

        if (!string.IsNullOrWhiteSpace(emailMetadata.Bcc)) email = email.BCC(emailMetadata.Bcc);

        if (!string.IsNullOrWhiteSpace(emailMetadata.Cc)) email = email.CC(emailMetadata.Cc);

        var policy = pipelineProvider.GetPipeline(nameof(Smtp));

        await policy.ExecuteAsync(async token => await email.SendAsync(token), cancellationToken);
    }
}