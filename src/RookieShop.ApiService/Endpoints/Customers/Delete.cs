using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.Application.Customers.Commands.Delete;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Customers;

public sealed class Delete(ISender sender) : IEndpoint<NoContent, DeleteCustomerRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapDelete("/customers/{id}", async (CustomerId id) => await HandleAsync(new(id)))
            .Produces<NoContent>(StatusCodes.Status204NoContent)
            .Produces<NotFound<string>>(StatusCodes.Status404NotFound)
            .WithTags(nameof(Customers))
            .WithName("Delete Customer")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<NoContent> HandleAsync(DeleteCustomerRequest request,
        CancellationToken cancellationToken = default)
    {
        DeleteCustomerCommand command = new(request.Id);

        await sender.Send(command, cancellationToken);

        return TypedResults.NoContent();
    }
}