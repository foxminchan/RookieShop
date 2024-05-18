using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Baskets;
using RookieShop.Application.Baskets.Queries.Get;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Baskets;

public sealed class Get(ISender sender) : IEndpoint<Ok<BasketVm>, GetBasketRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/baskets/{id:guid}", async (Guid id) => await HandleAsync(new(id)))
            .Produces<Ok<BasketVm>>()
            .Produces<NotFound<string>>(StatusCodes.Status404NotFound)
            .WithTags(nameof(Baskets))
            .WithName("Get Basket")
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(JwtBearerDefaults.AuthenticationScheme)
            .RequirePerUserRateLimit();

    public async Task<Ok<BasketVm>> HandleAsync(GetBasketRequest request, CancellationToken cancellationToken = default)
    {
        GetBasketQuery query = new(request.Id);

        var basket = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(basket.Value.ToBasketVm());
    }
}