namespace RookieShop.Storefront.Options;

public sealed class AppSettings
{
    public string ApiEndpoint { get; set; } = string.Empty;

    public OpenIdSettings OpenIdSettings { get; set; } = new();
}