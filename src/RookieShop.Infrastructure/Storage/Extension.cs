using Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Polly;
using RookieShop.Infrastructure.Storage.Azurite;
using RookieShop.Infrastructure.Storage.Azurite.Internal;
using RookieShop.Infrastructure.Storage.Azurite.Settings;
using RookieShop.Infrastructure.Validator;

namespace RookieShop.Infrastructure.Storage;

public static class Extension
{
    public static IHostApplicationBuilder AddStorage(this IHostApplicationBuilder builder)
    {
        builder.Services.AddOptionsWithValidateOnStart<AzuriteSettings>()
            .Bind(builder.Configuration.GetSection(nameof(AzuriteSettings)))
            .ValidateFluentValidation();

        builder.Services.AddSingleton(options => options.GetRequiredService<IOptions<AzuriteSettings>>().Value);

        builder.Services.AddResiliencePipeline(nameof(Azurite), resiliencePipelineBuilder => resiliencePipelineBuilder
            .AddRetry(new()
            {
                ShouldHandle = new PredicateBuilder().Handle<RequestFailedException>(),
                Delay = TimeSpan.FromSeconds(2),
                MaxRetryAttempts = 3,
                BackoffType = DelayBackoffType.Constant
            })
            .AddTimeout(TimeSpan.FromSeconds(10)));

        builder.Services.AddSingleton<IAzuriteService, AzuriteService>();

        return builder;
    }
}