using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Categories;
using RookieShop.Application.Categories.Queries.List;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Categories;

public sealed class List(ISender sender) : IEndpoint<Ok<ListCategoriesResponse>, ListCategoriesRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/categories",
                async (int pageIndex = 1, int pageSize = 0, string? search = null)
                    => await HandleAsync(new(pageIndex, pageSize, search)))
            .Produces<Ok<ListCategoriesResponse>>()
            .WithTags(nameof(Categories))
            .WithName("List Categories")
            .MapToApiVersion(new(1, 0))
            .RequirePerIpRateLimit();

    public async Task<Ok<ListCategoriesResponse>> HandleAsync(ListCategoriesRequest request,
        CancellationToken cancellationToken = default)
    {
        ListCategoriesQuery query = new(request.PageIndex, request.PageSize, request.Search);

        var result = await sender.Send(query, cancellationToken);

        ListCategoriesResponse response = new()
        {
            PageInfo = result.PagedInfo,
            Categories = result.Value.ToCategoryVm()
        };

        return TypedResults.Ok(response);
    }
}