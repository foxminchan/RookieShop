namespace RookieShop.ApiService.Options;

public sealed class AppSettings
{
    public CorsSettings CorsSettings { get; set; } = new();
}