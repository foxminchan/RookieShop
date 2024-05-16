using Ardalis.GuardClauses;
using Ardalis.Result;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace RookieShop.ApiService.Middlewares;

public sealed class ExceptionHandler(ILogger<ExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "[{Handler}] Exception occurred: {ExceptionMessage}", nameof(ExceptionHandler),
            exception.Message);

        switch (exception)
        {
            case ValidationException validationException:
                await HandleValidationException(httpContext, validationException, cancellationToken);
                break;

            case NotFoundException notFoundException:
                await HandleNotFoundException(httpContext, notFoundException, cancellationToken);
                break;

            default:
                await HandleDefaultException(httpContext, exception, cancellationToken);
                break;
        }

        return true;
    }

    private static async ValueTask<bool> HandleValidationException(
        HttpContext httpContext,
        ValidationException validationException,
        CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        if (validationException.Errors.Any())
        {
            var validationErrorModel = Result.Invalid(validationException
                .Errors
                .Select(e => new ValidationError(
                    e.PropertyName,
                    e.ErrorMessage,
                    StatusCodes.Status400BadRequest.ToString(),
                    ValidationSeverity.Info
                )).ToList());

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            await httpContext.Response.WriteAsJsonAsync(TypedResults.BadRequest(validationErrorModel.ValidationErrors),
                cancellationToken);
        }
        else
        {
            await httpContext.Response.WriteAsJsonAsync(TypedResults.BadRequest(validationException.Message),
                cancellationToken);
        }

        return true;
    }

    private static async ValueTask<bool> HandleNotFoundException(
        HttpContext httpContext,
        Exception notFoundException,
        CancellationToken cancellationToken)
    {
        var notFoundErrorModel = Result.NotFound(notFoundException.Message);

        httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

        await httpContext.Response.WriteAsJsonAsync(TypedResults.NotFound(notFoundErrorModel.Errors[0]),
            cancellationToken);

        return true;
    }

    private static async ValueTask<bool> HandleDefaultException(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        ProblemDetails details = new()
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = exception.GetType().Name,
            Title = "An error occurred while processing your request",
            Detail = exception.Message,
            Instance = $"{httpContext.Request.Method}{httpContext.Request.Path}"
        };

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(TypedResults.Problem(details), cancellationToken);

        return true;
    }
}