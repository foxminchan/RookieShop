﻿using Ardalis.GuardClauses;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Refit;
using RookieShop.Storefront.Areas.Basket.Services;
using RookieShop.Storefront.Areas.Order.Services;
using RookieShop.Storefront.Areas.Product.Services;
using RookieShop.Storefront.Areas.User.Services;
using RookieShop.Storefront.Delegates;
using RookieShop.Storefront.Services;

namespace RookieShop.Storefront.Configurations;

public static class ConfigureHttpServices
{
    public static IHostApplicationBuilder AddHttpServices(this IHostApplicationBuilder builder, string? apiEndpoint)
    {
        Guard.Against.NullOrEmpty(apiEndpoint);

        builder.Services.TryAddTransient<LoggingDelegate>();

        builder.Services.TryAddTransient<AuthorizeDelegate>();

        Type[] types =
        [
            typeof(ICategoryService),
            typeof(IProductService),
            typeof(IFeedbackService),
            typeof(IBasketService),
            typeof(ICustomerService),
            typeof(IOrderService),
            typeof(IReportService)
        ];

        foreach (var type in types)
        {
            builder.Services.AddRefitClient(type, new()
                {
                    CollectionFormat = CollectionFormat.Multi
                })
                .ConfigureHttpClient(c => c.BaseAddress = new(apiEndpoint))
                .AddHttpMessageHandler<LoggingDelegate>()
                .AddHttpMessageHandler<AuthorizeDelegate>();
        }

        return builder;
    }
}