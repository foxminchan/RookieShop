namespace RookieShop.Infrastructure.Merchant.Stripe.Abstractions;

public sealed record CreateChargeResource(
    string Currency,
    long Amount,
    string CustomerId,
    string ReceiptEmail,
    string Description);