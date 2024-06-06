namespace RookieShop.Storefront.Options;

public sealed class StripeSettings
{
    public string StripeSecretKey { get; set; } = string.Empty;
    public string StripeWebhookSecret { get; set; } = string.Empty;
}