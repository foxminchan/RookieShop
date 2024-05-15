using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.Application.Baskets.Queries.Get;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Baskets;

public sealed class Get(ISender sender) : IEndpoint<Ok<Basket>, GetBasketRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/baskets/{id:guid}", async (Guid id) => await HandleAsync(new(id)))
            .Produces<Ok<Basket>>()
            .WithTags(nameof(Baskets))
            .WithName("Get Basket")
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(JwtBearerDefaults.AuthenticationScheme)
            .RequirePerUserRateLimit();

    public async Task<Ok<Basket>> HandleAsync(GetBasketRequest request, CancellationToken cancellationToken = default)
    {
        GetBasketQuery query = new(request.Id);

        Basket basket = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(basket);
    }
}