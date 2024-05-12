namespace RookieShop.Infrastructure.GenAi.OpenAi.Settings;

public sealed class OpenAiSettings
{
    public string ApiKey { get; set; } = string.Empty;
    public string EmbeddingModel { get; set; } = string.Empty;
}