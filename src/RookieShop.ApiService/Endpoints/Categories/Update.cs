using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Categories;
using RookieShop.Application.Categories.Commands.Update;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Categories;

public sealed class Update(ISender sender) : IEndpoint<Ok<UpdateCategoryResponse>, UpdateCategoryRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPut("/categories", async (UpdateCategoryRequest request) => await HandleAsync(request))
            .Produces<Ok<UpdateCategoryResponse>>()
            .WithTags(nameof(Categories))
            .WithName("Update Category")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<Ok<UpdateCategoryResponse>> HandleAsync(UpdateCategoryRequest request,
        CancellationToken cancellationToken = default)
    {
        UpdateCategoryCommand command = new(request.Id, request.Name, request.Description);

        var result = await sender.Send(command, cancellationToken);

        UpdateCategoryResponse response = new(result.Value.ToCategoryVm());

        return TypedResults.Ok(response);
    }
}