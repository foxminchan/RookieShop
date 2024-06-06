using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RookieShop.ApiService.Filters;
using RookieShop.Application.Products.Queries.CheckStock;
using RookieShop.Domain.Constants;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Products;

public sealed class CheckStock(ISender sender) : IEndpoint<Ok<CheckStockResponse>, CheckStockRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPost("/products/check-stock",
                async ([FromHeader(Name = HeaderName.IdempotencyKey)] string key, CheckStockRequest request) =>
                await HandleAsync(request))
            .AddEndpointFilter<IdempotencyFilter>()
            .Produces<Ok<CheckStockResponse>>()
            .Produces(StatusCodes.Status400BadRequest)
            .WithTags(nameof(Products))
            .WithName("Check Stock")
            .MapToApiVersion(new(1, 0))
            .RequirePerIpRateLimit();

    public async Task<Ok<CheckStockResponse>> HandleAsync(CheckStockRequest request,
        CancellationToken cancellationToken = default)
    {
        CheckStockQuery query = new(request.Requests);

        var result = await sender.Send(query, cancellationToken);

        CheckStockResponse response = new(result.Value);

        return TypedResults.Ok(response);
    }
}