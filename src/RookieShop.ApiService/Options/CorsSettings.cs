namespace RookieShop.ApiService.Options;

public sealed class CorsSettings
{
    public string[] AllowedOrigins { get; set; } = [];
}