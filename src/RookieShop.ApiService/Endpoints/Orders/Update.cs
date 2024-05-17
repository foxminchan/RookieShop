using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RookieShop.ApiService.Filters;
using RookieShop.ApiService.ViewModels.Orders;
using RookieShop.Application.Orders.Command.Update;
using RookieShop.Domain.Constants;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Orders;

public sealed class Update(ISender sender) : IEndpoint<Ok<UpdateOrderResponse>, UpdateOrderRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPatch("/orders",
                async ([FromHeader(Name = HeaderName.IdempotencyKey)] string key, UpdateOrderRequest request) =>
                await HandleAsync(request))
            .AddEndpointFilter<IdempotencyFilter>()
            .Produces<Ok<UpdateOrderResponse>>()
            .WithTags(nameof(Orders))
            .WithName("Update Order")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<Ok<UpdateOrderResponse>> HandleAsync(UpdateOrderRequest request,
        CancellationToken cancellationToken = default)
    {
        UpdateOrderCommand command = new(request.Id, request.OrderStatus);

        var result = await sender.Send(command, cancellationToken);

        UpdateOrderResponse response = new(result.Value.ToOrderVm());

        return TypedResults.Ok(response);
    }
}