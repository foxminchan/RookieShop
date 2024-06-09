using Microsoft.SemanticKernel;
using RookieShop.Storefront.Options;

namespace RookieShop.Storefront.Configurations;

public static class ConfigureAiService
{
    public static IHostApplicationBuilder AddAiService(this IHostApplicationBuilder builder, AiOptions aiOptions)
    {
        builder.Services.AddKernel();

        builder.AddAzureOpenAIClient("openai");

        builder.Services.AddAzureOpenAIChatCompletion(aiOptions.OpenAi.ModelName);

        return builder;
    }
}