using System.Diagnostics;
using System.Text.Json;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RookieShop.ServiceDefaults.OpenTelemetry;
using RookieShop.ServiceDefaults.OpenTelemetry.ActivityScope;

namespace RookieShop.Infrastructure.Validator;

[DebuggerStepThrough]
public sealed class RequestValidationBehavior<TRequest, TResponse>(
    IServiceProvider serviceProvider,
    ILogger<RequestValidationBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        const string behavior = nameof(RequestValidationBehavior<TRequest, TResponse>);

        logger.LogInformation(
            "[{Behavior}] handle request={RequestData} and response={ResponseData}",
            behavior, typeof(TRequest).FullName, typeof(TResponse).FullName);

        logger.LogDebug(
            "[{Behavior}] handle request={Request} with content={RequestData}",
            behavior, typeof(TRequest).FullName, JsonSerializer.Serialize(request));

        var validators = serviceProvider
                             .GetService<IEnumerable<IValidator<TRequest>>>()?.ToList()
                         ?? throw new InvalidOperationException();

        var activityScope = serviceProvider.GetRequiredService<IActivityScope>();

        if (validators.Count != 0)
            await Task.WhenAll(
                validators.Select(v => v.HandleValidationAsync(request))
            );

        var response = await next();

        logger.LogInformation(
            "[{Behavior}] handled response={Response} with content={ResponseData}",
            behavior, typeof(TResponse).FullName, JsonSerializer.Serialize(response));

        await activityScope.Run(
            behavior,
            async (_, _) => await next(),
            new()
            {
                Tags =
                {
                    {
                        TelemetryTags.Validator.Validation, typeof(TRequest).Name
                    },
                    {
                        TelemetryTags.Validator.ValidationRequest, JsonSerializer.Serialize(request)
                    },
                    {
                        TelemetryTags.Validator.ValidationResponseType, typeof(TResponse).FullName
                    },
                    {
                        TelemetryTags.Validator.ValidationResponse, JsonSerializer.Serialize(response)
                    },
                    {
                        TelemetryTags.Validator.ValidationValidators, JsonSerializer.Serialize(validators)
                    }
                }
            },
            cancellationToken
        );

        return response;
    }
}