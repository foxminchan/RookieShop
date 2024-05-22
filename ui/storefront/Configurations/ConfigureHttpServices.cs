using Ardalis.GuardClauses;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Refit;
using RookieShop.Storefront.Areas.Product.Services;
using RookieShop.Storefront.Delegates;

namespace RookieShop.Storefront.Configurations;

public static class ConfigureHttpServices
{
    public static IHostApplicationBuilder AddHttpServices(this IHostApplicationBuilder builder, string? apiEndpoint)
    {
        Guard.Against.NullOrEmpty(apiEndpoint);

        builder.Services.TryAddTransient<RetryDelegate>();

        builder.Services.TryAddTransient<LoggingDelegate>();

        builder.Services.TryAddTransient<AuthorizeDelegate>();

        Type[] types =
        [
            typeof(ICategoryService),
            typeof(IProductService)
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