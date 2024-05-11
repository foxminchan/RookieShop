using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RookieShop.Infrastructure.Validator;

namespace RookieShop.Infrastructure.Storage.Azurite.Settings;

public sealed class AzuriteSettingsService(IHostApplicationBuilder builder) : IConfigureNamedOptions<AzuriteSettings>
{
    public void Configure(AzuriteSettings options) =>
        builder.Services.AddOptionsWithValidateOnStart<AzuriteSettings>()
            .Bind(builder.Configuration.GetSection(nameof(AzuriteSettings)))
            .ValidateFluentValidation();

    public void Configure(string? name, AzuriteSettings options) => Configure(options);
}