using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.Application.Categories.Commands.Delete;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Categories;

public sealed class Delete(ISender sender) : IEndpoint<NoContent, DeleteCategoryRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapDelete("/categories/{id}", async (CategoryId id) => await HandleAsync(new(id)))
            .Produces<NoContent>(StatusCodes.Status204NoContent)
            .WithTags(nameof(Categories))
            .WithName("Delete Category")
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(JwtBearerDefaults.AuthenticationScheme)
            .RequirePerUserRateLimit();

    public async Task<NoContent> HandleAsync(DeleteCategoryRequest request,
        CancellationToken cancellationToken = default)
    {
        DeleteCategoryCommand command = new(request.Id);

        await sender.Send(command, cancellationToken);

        return TypedResults.NoContent();
    }
}