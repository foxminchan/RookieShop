using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RookieShop.ApiService.Filters;
using RookieShop.Application.Categories.Commands.Create;
using RookieShop.Domain.Constants;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Categories;

public sealed class Create(ISender sender) : IEndpoint<Created<CreateCategoryResponse>, CreateCategoryRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPost("/categories",
                async (
                    [FromHeader(Name = HeaderName.IdempotencyKey)]
                    string key,
                    CreateCategoryRequest request) => await HandleAsync(request))
            .AddEndpointFilter<IdempotencyFilter>()
            .Produces<Created<CreateCategoryResponse>>(StatusCodes.Status201Created)
            .WithTags(nameof(Categories))
            .WithName("Create Category")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<Created<CreateCategoryResponse>> HandleAsync(CreateCategoryRequest request,
        CancellationToken cancellationToken = default)
    {
        CreateCategoryCommand command = new(request.Name, request.Description);

        var result = await sender.Send(command, cancellationToken);

        CreateCategoryResponse response = new(result.Value);

        return TypedResults.Created($"/api/categories/{result.Value}", response);
    }
}