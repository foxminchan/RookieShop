using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Products;
using RookieShop.Application.Products.Queries.List;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Products;

public sealed class List(ISender sender) : IEndpoint<Ok<ListProductsResponse>, ListProductsRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/products",
                async (
                        int pageNumber = 1,
                        int pageSize = 0,
                        string? orderBy = nameof(ProductVm.Id),
                        bool isDescending = false,
                        CategoryId? categoryId = null) =>
                    await HandleAsync(new(pageNumber, pageSize, orderBy, isDescending, categoryId)))
            .Produces<Ok<ListProductsResponse>>()
            .WithTags(nameof(Products))
            .WithName("List Products")
            .MapToApiVersion(new(1, 0))
            .RequirePerIpRateLimit();

    public async Task<Ok<ListProductsResponse>> HandleAsync(ListProductsRequest request,
        CancellationToken cancellationToken = default)
    {
        ListProductsQuery query = new(
            request.PageIndex,
            request.PageSize,
            request.OrderBy,
            request.IsDescending,
            request.CategoryId);

        var result = await sender.Send(query, cancellationToken);

        ListProductsResponse response = new()
        {
            PagedInfo = result.PagedInfo,
            Products = result.Value.ToProductVm()
        };

        return TypedResults.Ok(response);
    }
}