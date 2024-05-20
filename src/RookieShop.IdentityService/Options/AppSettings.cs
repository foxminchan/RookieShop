namespace RookieShop.IdentityService.Options;

public sealed class AppSettings
{
    public ProviderSettings Provider { get; set; } = new();

    public ClientSettings Client { get; set; } = new();
}