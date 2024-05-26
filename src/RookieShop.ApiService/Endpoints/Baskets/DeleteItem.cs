using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.Application.Baskets.Command.DeleteItem;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Baskets;

public sealed class DeleteItem(ISender sender) : IEndpoint<NoContent, DeleteItemRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapDelete("/baskets/items",
                async (Guid accountId, ProductId productId) => await HandleAsync(new(accountId, productId)))
            .Produces<NoContent>(StatusCodes.Status204NoContent)
            .Produces<NotFound<string>>(StatusCodes.Status404NotFound)
            .WithTags(nameof(Baskets))
            .WithName("Delete Item")
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(JwtBearerDefaults.AuthenticationScheme)
            .RequirePerUserRateLimit();

    public async Task<NoContent>
        HandleAsync(DeleteItemRequest request, CancellationToken cancellationToken = default)
    {
        DeleteItemCommand command = new(request.AccountId, request.ProductId);

        await sender.Send(command, cancellationToken);

        return TypedResults.NoContent();
    }
}