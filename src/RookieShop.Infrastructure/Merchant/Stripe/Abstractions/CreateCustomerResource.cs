namespace RookieShop.Infrastructure.Merchant.Stripe.Abstractions;

public sealed record CreateCustomerResource(
    string Email,
    string Name,
    CreateCardResource Card);