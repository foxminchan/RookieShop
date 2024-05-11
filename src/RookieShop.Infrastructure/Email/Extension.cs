using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RookieShop.Infrastructure.Email.Smtp;
using RookieShop.Infrastructure.Email.Smtp.Internal;
using RookieShop.Infrastructure.Email.Smtp.Settings;

namespace RookieShop.Infrastructure.Email;

public static class Extension
{
    public static IHostApplicationBuilder AddEmail(this IHostApplicationBuilder builder)
    {
        SmtpSettings smtpSettings = new();

        builder.Services.AddSingleton<IConfigureOptions<SmtpSettings>, SmtpSettingsService>();

        builder.Services.AddFluentEmail(smtpSettings.Email, nameof(RookieShop))
            .AddSmtpSender(smtpSettings.Host, smtpSettings.Port, smtpSettings.Email, smtpSettings.Secret)
            .AddRazorRenderer();

        builder.Services.AddScoped(typeof(ISmtpService<>), typeof(SmtpService<>));

        return builder;
    }
}