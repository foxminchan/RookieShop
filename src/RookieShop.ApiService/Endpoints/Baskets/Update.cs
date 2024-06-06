using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RookieShop.ApiService.Filters;
using RookieShop.ApiService.ViewModels.Baskets;
using RookieShop.Application.Baskets.Commands.Update;
using RookieShop.Domain.Constants;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Baskets;

public sealed class Update(ISender sender) : IEndpoint<Ok<BasketVm>, UpdateBasketRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPatch("/baskets",
                async ([FromHeader(Name = HeaderName.IdempotencyKey)] string key, UpdateBasketRequest basket) =>
                await HandleAsync(basket))
            .AddEndpointFilter<IdempotencyFilter>()
            .Produces<Ok<BasketVm>>()
            .Produces<NotFound<string>>(StatusCodes.Status404NotFound)
            .Produces<BadRequest<IEnumerable<ValidationError>>>(StatusCodes.Status400BadRequest)
            .WithTags(nameof(Baskets))
            .WithName("Update Basket Quantity")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<Ok<BasketVm>> HandleAsync(UpdateBasketRequest request,
        CancellationToken cancellationToken = default)
    {
        UpdateBasketCommand command = new(request.AccountId, request.ProductId, request.Quantity);

        var result = await sender.Send(command, cancellationToken);

        return TypedResults.Ok(result.Value.ToBasketVm());
    }
}