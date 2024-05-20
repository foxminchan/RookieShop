using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieShop.Infrastructure.Merchant.Settings;
using RookieShop.Infrastructure.Merchant.Stripe;
using RookieShop.Infrastructure.Merchant.Stripe.Internal;
using RookieShop.Infrastructure.Validator;
using Stripe;

namespace RookieShop.Infrastructure.Merchant;

public static class Extension
{
    public static IHostApplicationBuilder AddStripeService(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<TokenService>();

        builder.Services.AddScoped<CustomerService>();

        builder.Services.AddScoped<ChargeService>();

        builder.Services.AddOptionsWithValidateOnStart<StripeSettings>()
            .Bind(builder.Configuration.GetSection(nameof(StripeSettings)))
            .ValidateFluentValidation();

        var stripeSettings = builder.Configuration.GetSection(nameof(StripeSettings)).Get<StripeSettings>();

        Guard.Against.Null(stripeSettings);

        StripeConfiguration.ApiKey = stripeSettings.SecretKey;

        builder.Services.AddScoped<IStripeService, StripeService>();

        return builder;
    }
}