using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RookieShop.ApiService.Filters;
using RookieShop.Application.Baskets.Command.Create;
using RookieShop.Domain.Constants;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Baskets;

public sealed class Create(ISender sender) : IEndpoint<Created<CreateBasketResponse>, CreateBasketRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPost("/baskets",
                async ([FromHeader(Name = HeaderName.IdempotencyKey)] string key, CreateBasketRequest request) =>
                await HandleAsync(request))
            .AddEndpointFilter<IdempotencyFilter>()
            .Produces<CreateBasketResponse>(StatusCodes.Status201Created)
            .WithTags(nameof(Baskets))
            .WithName("Create Basket")
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(JwtBearerDefaults.AuthenticationScheme)
            .RequirePerUserRateLimit();

    public async Task<Created<CreateBasketResponse>> HandleAsync(CreateBasketRequest request,
        CancellationToken cancellationToken = default)
    {
        CreateBasketCommand command = new(request.AccountId, request.BasketDetails);

        var result = await sender.Send(command, cancellationToken);

        CreateBasketResponse response = new(result.Value);

        return TypedResults.Created($"/api/baskets/{result.Value}", response);
    }
}