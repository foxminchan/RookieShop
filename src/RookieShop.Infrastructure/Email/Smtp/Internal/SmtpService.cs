using FluentEmail.Core;
using Polly.Registry;
using RookieShop.Infrastructure.Email.Smtp.Abstractions;

namespace RookieShop.Infrastructure.Email.Smtp.Internal;

public sealed class SmtpService<T>(
    IFluentEmailFactory factory, 
    ResiliencePipelineProvider<string> pipeline) : ISmtpService<T>
    where T : notnull
{
    public async Task SendEmailAsync(EmailMetadata<T> emailMetadata, CancellationToken cancellationToken = default)
    {
        var email = factory.Create();

        email = email
            .To(emailMetadata.To)
            .Subject(emailMetadata.Subject)
            .UsingTemplate(emailMetadata.Template, emailMetadata.Model);

        if (!string.IsNullOrWhiteSpace(emailMetadata.Bcc)) email = email.BCC(emailMetadata.Bcc);

        if (!string.IsNullOrWhiteSpace(emailMetadata.Cc)) email = email.CC(emailMetadata.Cc);

        var policy = pipeline.GetPipeline(nameof(Smtp));

        await policy.ExecuteAsync(async token => await email.SendAsync(token), cancellationToken);
    }
}