using Microsoft.Extensions.DependencyInjection.Extensions;
using Refit;
using RookieShop.Storefront.Delegates;
using RookieShop.Storefront.Services;

namespace RookieShop.Storefront.Configurations;

public static class ConfigureWebServices
{
    public static IHostApplicationBuilder AddWebServices(this IHostApplicationBuilder builder, string apiEndpoint)
    {
        builder.Services.TryAddTransient<RetryDelegate>();

        builder.Services.TryAddTransient<LoggingDelegate>();

        builder.Services.TryAddTransient<AuthorizeDelegate>();

        Type[] types =
        [
            typeof(ICategoryService)
        ];

        foreach (var type in types)
        {
            builder.Services.AddRefitClient(type, new()
                {
                    CollectionFormat = CollectionFormat.Multi
                })
                .ConfigureHttpClient(c => c.BaseAddress = new(apiEndpoint))
                .AddHttpMessageHandler<RetryDelegate>()
                .AddHttpMessageHandler<LoggingDelegate>()
                .AddHttpMessageHandler<AuthorizeDelegate>();
        }

        return builder;
    }
}