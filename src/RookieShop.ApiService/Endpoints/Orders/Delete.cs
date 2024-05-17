using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.Application.Orders.Command.Delete;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Orders;

public sealed class Delete(ISender sender) : IEndpoint<NoContent, DeleteOrderRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapDelete("/orders/{id}", async (OrderId id) => await HandleAsync(new(id)))
            .Produces<NoContent>(StatusCodes.Status204NoContent)
            .WithTags(nameof(Orders))
            .WithName("Delete Order")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<NoContent>
        HandleAsync(DeleteOrderRequest request, CancellationToken cancellationToken = default)
    {
        DeleteOrderCommand command = new(request.Id);

        await sender.Send(command, cancellationToken);

        return TypedResults.NoContent();
    }
}