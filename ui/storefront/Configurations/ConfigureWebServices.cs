using Refit;
using RookieShop.Storefront.Delegates;

namespace RookieShop.Storefront.Configurations;

public static class ConfigureWebServices
{
    public static IHostApplicationBuilder AddWebServices(this IHostApplicationBuilder builder, Type[] type, string apiEndpoint)
    {
        builder.Services.AddTransient<RetryDelegate>();

        builder.Services.AddTransient<LoggingDelegate>();

        foreach (var t in type)
        {
            builder.Services.AddRefitClient(t)
                .ConfigureHttpClient(c => c.BaseAddress = new(apiEndpoint))
                .AddHttpMessageHandler<RetryDelegate>()
                .AddHttpMessageHandler<LoggingDelegate>();
        }

        return builder;
    }
}