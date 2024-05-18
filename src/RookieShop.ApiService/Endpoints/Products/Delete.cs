using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.Application.Products.Commands.Delete;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Products;

public sealed class Delete(ISender sender) : IEndpoint<NoContent, DeleteProductRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapDelete("/products/{id}", async (ProductId id) => await HandleAsync(new(id)))
            .Produces<NoContent>(StatusCodes.Status204NoContent)
            .Produces<NotFound<string>>(StatusCodes.Status404NotFound)
            .WithTags(nameof(Products))
            .WithName("Delete Product")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<NoContent> HandleAsync(DeleteProductRequest request,
        CancellationToken cancellationToken = default)
    {
        DeleteProductCommand command = new(request.Id);

        await sender.Send(command, cancellationToken);

        return TypedResults.NoContent();
    }
}