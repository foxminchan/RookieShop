using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.Application.Baskets.Command.Update;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Baskets;

public sealed class Update(ISender sender) : IEndpoint<Ok<UpdateBasketResponse>, UpdateBasketRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPut("/baskets", async (UpdateBasketRequest request) => await HandleAsync(request))
            .Produces<Ok<UpdateBasketResponse>>()
            .WithTags(nameof(Baskets))
            .WithName("Update Basket")
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(JwtBearerDefaults.AuthenticationScheme)
            .RequirePerUserRateLimit();

    public async Task<Ok<UpdateBasketResponse>> HandleAsync(UpdateBasketRequest request,
        CancellationToken cancellationToken = default)
    {
        UpdateBasketCommand command = new(request.AccountId, request.BasketDetails);

        Basket basket = await sender.Send(command, cancellationToken);

        UpdateBasketResponse response = new(basket);

        return TypedResults.Ok(response);
    }
}