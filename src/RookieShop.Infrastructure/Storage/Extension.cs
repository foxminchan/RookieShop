using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RookieShop.Infrastructure.Storage.Azurite;
using RookieShop.Infrastructure.Storage.Azurite.Internal;
using RookieShop.Infrastructure.Storage.Azurite.Settings;

namespace RookieShop.Infrastructure.Storage;

public static class Extension
{
    public static IHostApplicationBuilder AddStorage(this IHostApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IConfigureOptions<AzuriteSettings>, AzuriteSettingsService>();

        builder.Services.AddSingleton<IAzuriteService, AzuriteService>();

        return builder;
    }
}