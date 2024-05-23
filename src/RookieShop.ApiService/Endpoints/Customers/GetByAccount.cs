using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Customers;
using RookieShop.Application.Customers.Queries.GetByAccount;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Customers;

public sealed class GetByAccount(ISender sender) : IEndpoint<Ok<CustomerVm?>, GetByAccountRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/customers/account/{accountId}", async (Guid accountId) => await HandleAsync(new(accountId)))
            .Produces<Ok<CustomerVm?>>()
            .WithTags(nameof(Customers))
            .WithName("Get Customer By Account")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<Ok<CustomerVm?>> HandleAsync(GetByAccountRequest request,
        CancellationToken cancellationToken = default)
    {
        GetByAccountQuery query = new(request.AccountId);

        var result = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(result.Value?.ToCustomerVm())!;
    }
}