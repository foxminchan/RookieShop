using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RookieShop.ApiService.Filters;
using RookieShop.Application.Orders.Command.Create;
using RookieShop.Domain.Constants;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Orders;

public sealed class Create(ISender sender) : IEndpoint<Created<CreateOrderResponse>, CreateOrderRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPost("/orders",
                async ([FromHeader(Name = HeaderName.IdempotencyKey)] string key, CreateOrderRequest request) =>
                await HandleAsync(request))
            .AddEndpointFilter<IdempotencyFilter>()
            .Produces<Created<CreateOrderResponse>>(StatusCodes.Status201Created)
            .Produces<BadRequest<IEnumerable<ValidationError>>>(StatusCodes.Status400BadRequest)
            .WithTags(nameof(Orders))
            .WithName("Create Order")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<Created<CreateOrderResponse>> HandleAsync(CreateOrderRequest request,
        CancellationToken cancellationToken = default)
    {
        CreateOrderCommand command = new(
            request.PaymentMethod,
            request.CardHolderName,
            request.Number,
            request.ExpiryYear,
            request.ExpiryMonth,
            request.Cvc,
            request.Street,
            request.City,
            request.Province,
            request.AccountId);

        var result = await sender.Send(command, cancellationToken);

        CreateOrderResponse response = new(result.Value);

        return TypedResults.Created($"/api/orders/{result.Value}", response);
    }
}