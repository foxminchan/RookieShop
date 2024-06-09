namespace RookieShop.Storefront.Options;

public class AppSettings
{
    public string BaseApiEndpoint { get; set; } = string.Empty;
    public StripeSettings StripeSettings { get; set; } = new();
    public OpenIdSettings OpenIdSettings { get; set; } = new();
    public AiOptions AiOptions { get; set; } = new();
}