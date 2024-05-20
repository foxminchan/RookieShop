namespace RookieShop.IdentityService.Options;

public sealed class ProviderSettings
{
    public GoogleSettings Google { get; set; } = new();
}