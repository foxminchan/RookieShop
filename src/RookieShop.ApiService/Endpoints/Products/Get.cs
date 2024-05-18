using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Products;
using RookieShop.Application.Products.Queries.Get;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Products;

public sealed class Get(ISender sender) : IEndpoint<Ok<ProductVm>, GetProductRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/products/{id}", async (ProductId id) => await HandleAsync(new(id)))
            .Produces<ProductVm>()
            .WithTags(nameof(Products))
            .WithName("Get Product")
            .MapToApiVersion(new(1, 0))
            .RequirePerIpRateLimit();

    public async Task<Ok<ProductVm>> HandleAsync(GetProductRequest request,
        CancellationToken cancellationToken = default)
    {
        GetProductQuery query = new(request.Id);

        var result = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(result.Value.ToProductVm());
    }
}