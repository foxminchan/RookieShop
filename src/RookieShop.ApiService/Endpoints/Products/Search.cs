using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Products;
using RookieShop.Application.Products.Queries.Search;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Products;

public sealed class Search(ISender sender) : IEndpoint<Ok<SearchProductResponse>, SearchProductRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/products/search",
                async (
                        string context,
                        int pageNumber = 1,
                        int pageSize = 0) =>
                    await HandleAsync(new(context, pageNumber, pageSize)))
            .Produces<Ok<SearchProductResponse>>()
            .WithTags(nameof(Products))
            .WithName("Search Products")
            .MapToApiVersion(new(1, 0))
            .RequirePerIpRateLimit();

    public async Task<Ok<SearchProductResponse>> HandleAsync(SearchProductRequest request,
        CancellationToken cancellationToken = default)
    {
        SearchProductQuery query = new(
            request.Context,
            request.PageIndex,
            request.PageSize);

        var result = await sender.Send(query, cancellationToken);

        SearchProductResponse response = new()
        {
            PagedInfo = result.PagedInfo,
            Products = result.Value.ToProductVm()
        };

        return TypedResults.Ok(response);
    }
}