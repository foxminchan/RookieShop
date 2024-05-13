using FluentValidation;
using RookieShop.Domain.Constants;
using RookieShop.Infrastructure.Cache.Redis;

namespace RookieShop.ApiService.Filters;

public sealed class IdempotencyFilter(IRedisService redisService) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var request = context.HttpContext.Request;
        var requestMethod = request.Method;
        var requestPath = request.Path;
        var requestId = request.Headers[HeaderName.IdempotencyKey].FirstOrDefault();

        if (requestMethod is not "POST" and not "PATCH")
            return await next(context);

        if (string.IsNullOrEmpty(requestId))
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            throw new ValidationException("X-Idempotency-Key header is required for POST and PATCH requests.");
        }

        var cacheKey = $"{requestMethod}:{requestPath}:{requestId}";

        var cacheValue = await redisService.GetOrSet(cacheKey, () => request.GetType().Name, TimeSpan.FromMinutes(1));

        if (string.IsNullOrEmpty(cacheValue))
            return await next(context);

        context.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
        return TypedResults.Conflict();
    }
}