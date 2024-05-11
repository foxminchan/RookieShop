namespace RookieShop.Infrastructure.Merchant.Stripe.Abstractions;

public sealed record CreateCardResource(
    string Name,
    string Number,
    string ExpiryYear,
    string ExpiryMonth,
    string Cvc);