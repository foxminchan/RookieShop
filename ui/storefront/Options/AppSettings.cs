namespace RookieShop.Storefront.Options;

public sealed class AppSettings
{
    public OpenIdSettings OpenIdSettings { get; set; } = new();
}