namespace RookieShop.Infrastructure.Merchant.Stripe.Abstractions;

public sealed record CreateChargeResource(
    decimal Amount,
    string CustomerId,
    string ReceiptEmail,
    string Description,
    string? Currency = null);