using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Customers;
using RookieShop.Application.Customers.Queries.List;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Customers;

public sealed class List(ISender sender) : IEndpoint<Ok<ListCustomersResponse>, ListCustomersRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/customers",
                async (int pageIndex = 1, int pageSize = 0, string? search = null) =>
                    await HandleAsync(new(pageIndex, pageSize, search)))
            .Produces<Ok<ListCustomersResponse>>()
            .WithTags(nameof(Customers))
            .WithName("List Customers")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<Ok<ListCustomersResponse>> HandleAsync(ListCustomersRequest request,
        CancellationToken cancellationToken = default)
    {
        ListCustomersQuery query = new(request.PageIndex, request.PageSize, request.Name);

        var result = await sender.Send(query, cancellationToken);

        ListCustomersResponse response = new()
        {
            PagedInfo = result.PagedInfo,
            Customers = result.Value.ToCustomerVm()
        };

        return TypedResults.Ok(response);
    }
}