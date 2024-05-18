using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Orders;
using RookieShop.Application.Orders.Queries.Get;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Orders;

public sealed class Get(ISender sender) : IEndpoint<Ok<OrderVm>, GetOrderRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/orders/{id}", async (OrderId id) => await HandleAsync(new(id)))
            .Produces<Ok<OrderVm>>()
            .Produces<NotFound<string>>(StatusCodes.Status404NotFound)
            .WithTags(nameof(Orders))
            .WithName("Get Order")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<Ok<OrderVm>> HandleAsync(GetOrderRequest request, CancellationToken cancellationToken = default)
    {
        GetOrderQuery query = new(request.Id);

        var result = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(result.Value.ToOrderVm());
    }
}