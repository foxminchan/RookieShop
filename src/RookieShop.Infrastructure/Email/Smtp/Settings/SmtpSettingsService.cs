using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RookieShop.Infrastructure.Validator;

namespace RookieShop.Infrastructure.Email.Smtp.Settings;

public sealed class SmtpSettingsService(IHostApplicationBuilder builder) : IConfigureNamedOptions<SmtpSettings>
{
    public void Configure(SmtpSettings options) =>
        builder.Services.AddOptionsWithValidateOnStart<SmtpSettings>()
            .Bind(builder.Configuration.GetSection(nameof(SmtpSettings)))
            .ValidateFluentValidation();

    public void Configure(string? name, SmtpSettings options) => Configure(options);
}