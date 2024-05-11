namespace RookieShop.Infrastructure.Merchant.Stripe.Abstractions;

public sealed record CustomerResource(
    string CustomerId,
    string Email,
    string Name);