using Refit;
using RookieShop.Storefront.Delegates;
using RookieShop.Storefront.Services;

namespace RookieShop.Storefront.Configurations;

public static class ConfigureWebServices
{
    public static IHostApplicationBuilder AddWebServices(this IHostApplicationBuilder builder, string apiEndpoint)
    {
        builder.Services.AddTransient<RetryDelegate>();

        builder.Services.AddTransient<LoggingDelegate>();

        Type[] types =
        [
            typeof(ICategoryService)
        ];

        foreach (var type in types)
        {
            builder.Services.AddRefitClient(type)
                .ConfigureHttpClient(c => c.BaseAddress = new(apiEndpoint))
                .AddHttpMessageHandler<RetryDelegate>()
                .AddHttpMessageHandler<LoggingDelegate>();
        }

        return builder;
    }
}