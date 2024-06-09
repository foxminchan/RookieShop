namespace RookieShop.Storefront.Options;

public sealed class AiOptions
{
    public OpenAiOptions OpenAi { get; set; } = new();
}