using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Orders;
using RookieShop.Application.Orders.Queries.List;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.OrderAggregator.Enums;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Orders;

public sealed class List(ISender sender) : IEndpoint<Ok<ListOrdersResponse>, ListOrdersRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/orders",
                async (
                        int pageIndex = 1,
                        int pageSize = 0,
                        OrderStatus? status = null,
                        CustomerId? userId = null,
                        string? search = null) =>
                    await HandleAsync(new(pageIndex, pageSize, status, userId, search)))
            .Produces<Ok<ListOrdersResponse>>()
            .WithTags(nameof(Orders))
            .WithName("List Orders")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<Ok<ListOrdersResponse>> HandleAsync(ListOrdersRequest request,
        CancellationToken cancellationToken = default)
    {
        ListOrdersQuery query = new(
            request.PageIndex, 
            request.PageSize, 
            request.Status, 
            request.UserId,
            request.Search);

        var result = await sender.Send(query, cancellationToken);

        ListOrdersResponse response = new()
        {
            PagedInfo = result.PagedInfo,
            Orders = result.Value.ToOrderVm()
        };

        return TypedResults.Ok(response);
    }
}