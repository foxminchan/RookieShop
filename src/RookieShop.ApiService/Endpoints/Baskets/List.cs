using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Baskets;
using RookieShop.Application.Baskets.Queries.List;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Baskets;

public sealed class List(ISender sender) : IEndpointWithoutRequest<Ok<ListBasketsResponse>>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/baskets",
                async () => await HandleAsync())
            .Produces<Ok<ListBasketsResponse>>()
            .WithTags(nameof(Baskets))
            .WithName("List Baskets")
            .WithDescription("For dev purpose only")
            .MapToApiVersion(new(1, 0))
            .RequirePerIpRateLimit();

    public async Task<Ok<ListBasketsResponse>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var baskets = await sender.Send(new ListBasketsQuery(), cancellationToken);

        var response = baskets.Value.ToBasketVm().ToList();

        return TypedResults.Ok(new ListBasketsResponse(response));
    }
}