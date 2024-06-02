using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Application.Reports.Queries.BestSellerProducts;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Reports;

public sealed class BestSellerProducts(ISender sender)
    : IEndpoint<Ok<List<BestSellerProductsDto>>, BestSellerProductsRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/reports/best-seller-products",
                async (int top) => await HandleAsync(new(top)))
            .Produces<Ok<List<BestSellerProductsDto>>>()
            .WithTags(nameof(Reports))
            .WithName("Best Seller Products")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<Ok<List<BestSellerProductsDto>>> HandleAsync(BestSellerProductsRequest request,
        CancellationToken cancellationToken = default)
    {
        BestSellerProductsQuery query = new(request.Top);

        var result = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(result.Value.ToList());
    }
}