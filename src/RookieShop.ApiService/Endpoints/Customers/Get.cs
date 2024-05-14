using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Customers;
using RookieShop.Application.Customers.Queries.Get;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Customers;

public sealed class Get(ISender sender) : IEndpoint<Ok<CustomerVm>, GetCustomerRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/customers/{id}", async (CustomerId id) => await HandleAsync(new(id)))
            .Produces<Ok<CustomerVm>>()
            .WithTags(nameof(Customers))
            .WithName("Get Customer")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<Ok<CustomerVm>> HandleAsync(GetCustomerRequest request,
        CancellationToken cancellationToken = default)
    {
        GetCustomerQuery query = new(request.Id);

        var result = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(result.Value.ToCustomerVm());
    }
}