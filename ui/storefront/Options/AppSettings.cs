namespace RookieShop.Storefront.Options;

public sealed class AppSettings
{
    public string BaseApiEndpoint { get; set; } = string.Empty;
    public OpenIdSettings OpenIdSettings { get; set; } = new();
}