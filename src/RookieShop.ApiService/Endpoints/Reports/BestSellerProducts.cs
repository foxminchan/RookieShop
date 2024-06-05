using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Reports;
using RookieShop.Application.Reports.Queries.BestSellerProducts;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Reports;

public sealed class BestSellerProducts(ISender sender)
    : IEndpoint<Ok<List<BestSellerProductsVm>>, BestSellerProductsRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/reports/best-seller-products",
                async (int top) => await HandleAsync(new(top)))
            .Produces<Ok<List<BestSellerProductsVm>>>()
            .WithTags(nameof(Reports))
            .WithName("Best Seller Products")
            .MapToApiVersion(new(1, 0))
            .RequirePerIpRateLimit();

    public async Task<Ok<List<BestSellerProductsVm>>> HandleAsync(BestSellerProductsRequest request,
        CancellationToken cancellationToken = default)
    {
        BestSellerProductsQuery query = new(request.Top);

        var data = await sender.Send(query, cancellationToken);

        var result = data.Value.ToBestSellerProductsVm();

        return TypedResults.Ok(result);
    }
}