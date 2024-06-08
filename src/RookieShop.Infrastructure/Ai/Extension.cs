using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.SemanticKernel;
using RookieShop.Infrastructure.Ai.Embedded;
using RookieShop.Infrastructure.Ai.Embedded.Internal;

namespace RookieShop.Infrastructure.Ai;

public static class Extension
{
    public static IHostApplicationBuilder AddAi(this IHostApplicationBuilder builder)
    {
        builder.AddAzureOpenAIClient("openai");
        builder.Services.AddOpenAITextEmbeddingGeneration(
            builder.Configuration["AIOptions:OpenAI:EmbeddingName"] ?? "text-embedding-3-small");

        builder.Services.AddSingleton<IAiService, AiService>();

        return builder;
    }
}