using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using RookieShop.Infrastructure.Email.Smtp;
using RookieShop.Infrastructure.Email.Smtp.Internal;
using RookieShop.Infrastructure.Email.Smtp.Settings;
using RookieShop.Infrastructure.Validator;

namespace RookieShop.Infrastructure.Email;

public static class Extension
{
    public static IHostApplicationBuilder AddEmail(this IHostApplicationBuilder builder)
    {
        builder.Services.AddOptionsWithValidateOnStart<SmtpSettings>()
            .Bind(builder.Configuration.GetSection(nameof(SmtpSettings)))
            .ValidateFluentValidation();

        var smtpSettings = builder.Configuration.GetSection(nameof(SmtpSettings)).Get<SmtpSettings>();

        Guard.Against.Null(smtpSettings);

        builder.Services.AddFluentEmail(smtpSettings.Email, nameof(RookieShop))
            .AddSmtpSender(smtpSettings.Host, smtpSettings.Port, smtpSettings.Email, smtpSettings.Secret)
            .AddRazorRenderer();

        builder.Services.AddResiliencePipeline(nameof(Smtp), resiliencePipelineBuilder => resiliencePipelineBuilder
            .AddRetry(new()
            {
                ShouldHandle = new PredicateBuilder().Handle<Exception>(),
                Delay = TimeSpan.FromSeconds(2),
                MaxRetryAttempts = 3,
                BackoffType = DelayBackoffType.Constant
            })
            .AddTimeout(TimeSpan.FromSeconds(10)));

        builder.Services.AddScoped(typeof(ISmtpService<>), typeof(SmtpService<>));

        return builder;
    }
}