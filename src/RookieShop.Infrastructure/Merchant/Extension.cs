using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieShop.Infrastructure.Merchant.Stripe;
using RookieShop.Infrastructure.Merchant.Stripe.Internal;
using Stripe;

namespace RookieShop.Infrastructure.Merchant;

public static class Extension
{
    public static IHostApplicationBuilder AddStripeService(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<TokenService>();

        builder.Services.AddScoped<CustomerService>();

        builder.Services.AddScoped<ChargeService>();

        StripeConfiguration.ApiKey = builder.Configuration.GetValue<string>("Stripe:SecretKey");

        builder.Services.AddScoped<IStripeService, StripeService>();

        return builder;
    }
}