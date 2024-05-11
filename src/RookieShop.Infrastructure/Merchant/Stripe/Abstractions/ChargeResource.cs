namespace RookieShop.Infrastructure.Merchant.Stripe.Abstractions;

public sealed record ChargeResource(
    string Last4,
    string BrandName,
    string ChargeId);