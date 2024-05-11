using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

        builder.Services.AddScoped(typeof(ISmtpService<>), typeof(SmtpService<>));

        return builder;
    }
}