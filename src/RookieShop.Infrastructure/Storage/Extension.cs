using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieShop.Infrastructure.Storage.Azurite;
using RookieShop.Infrastructure.Storage.Azurite.Internal;
using RookieShop.Infrastructure.Storage.Azurite.Settings;
using RookieShop.Infrastructure.Validator;

namespace RookieShop.Infrastructure.Storage;

public static class Extension
{
    public static IHostApplicationBuilder AddStorage(this IHostApplicationBuilder builder)
    {
        builder.Services.AddOptionsWithValidateOnStart<AzuriteSettings>()
            .Bind(builder.Configuration.GetSection(nameof(AzuriteSettings)))
            .ValidateFluentValidation();

        builder.Services.AddSingleton<IAzuriteService, AzuriteService>();

        return builder;
    }
}