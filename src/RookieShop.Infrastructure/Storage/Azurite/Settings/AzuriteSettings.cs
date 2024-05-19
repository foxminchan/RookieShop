namespace RookieShop.Infrastructure.Storage.Azurite.Settings;

public sealed class AzuriteSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string ContainerName { get; set; } = string.Empty;
}