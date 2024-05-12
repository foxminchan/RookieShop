using Ardalis.GuardClauses;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.SemanticKernel;
using RookieShop.Infrastructure.GenAi.OpenAi;
using RookieShop.Infrastructure.GenAi.OpenAi.Internal;
using RookieShop.Infrastructure.GenAi.OpenAi.Settings;
using RookieShop.Infrastructure.Validator;

namespace RookieShop.Infrastructure.GenAi;

public static class Extension
{
    public static IHostApplicationBuilder AddGenAi(this IHostApplicationBuilder builder)
    {
        builder.Services.AddOptionsWithValidateOnStart<OpenAiSettings>()
            .Bind(builder.Configuration.GetSection(nameof(OpenAiSettings)))
            .ValidateFluentValidation();

        var openAiSettings = builder.Configuration.GetSection(nameof(OpenAiSettings)).Get<OpenAiSettings>();

        Guard.Against.Null(openAiSettings);

        builder.Services.AddSingleton(new OpenAIClient(openAiSettings.ApiKey));

        builder.Services.AddOpenAITextEmbeddingGeneration(openAiSettings.EmbeddingModel);

        builder.Services.AddSingleton<IOpenAiService, OpenAiService>();

        return builder;
    }
}