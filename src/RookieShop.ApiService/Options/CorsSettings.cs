namespace RookieShop.ApiService.Options;

public sealed class CorsSettings
{
    public string Storefront { get; set; } = string.Empty;

    public string Backoffice { get; set; } = string.Empty;
}