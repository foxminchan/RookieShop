using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.Application.Baskets.Command.Delete;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Baskets;

public sealed class Delete(ISender sender) : IEndpoint<NoContent, DeleteBasketRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapDelete("/baskets/{id:guid}", async (Guid id) => await HandleAsync(new(id)))
            .Produces<NoContent>(StatusCodes.Status204NoContent)
            .Produces<NotFound<string>>(StatusCodes.Status404NotFound)
            .WithTags(nameof(Baskets))
            .WithName("Delete Basket")
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(JwtBearerDefaults.AuthenticationScheme)
            .RequirePerUserRateLimit();

    public async Task<NoContent> HandleAsync(DeleteBasketRequest request, CancellationToken cancellationToken = default)
    {
        DeleteBasketCommand command = new(request.Id);

        await sender.Send(command, cancellationToken);

        return TypedResults.NoContent();
    }
}