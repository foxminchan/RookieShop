using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Categories;
using RookieShop.Application.Categories.Queries.Get;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Categories;

public sealed class Get(ISender sender) : IEndpoint<Ok<CategoryVm>, GetCategoryRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/categories/{id}",
                async (CategoryId id) => await HandleAsync(new(id)))
            .Produces<Ok<CategoryVm>>()
            .WithTags(nameof(Categories))
            .WithName("Get Category")
            .MapToApiVersion(new(1, 0))
            .RequirePerIpRateLimit();

    public async Task<Ok<CategoryVm>> HandleAsync(GetCategoryRequest request,
        CancellationToken cancellationToken = default)
    {
        GetCategoryQuery query = new(request.Id);

        var result = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(result.Value.ToCategoryVm());
    }
}