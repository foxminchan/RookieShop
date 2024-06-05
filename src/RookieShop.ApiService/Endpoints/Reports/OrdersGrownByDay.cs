using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Application.Reports.Queries.OrdersGrownByDay;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Reports;

public sealed class OrdersGrownByDay(ISender sender) : IEndpoint<Ok<OrdersGrownByDayDto>, OrdersGrownByDayRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/reports/orders-grown-by-day", async (DateTime? currentDate) => await HandleAsync(new()
            {
                CurrentDate = currentDate ?? DateTime.UtcNow
            }))
            .Produces<Ok<OrdersGrownByDayDto>>()
            .WithTags(nameof(Reports))
            .WithName("Orders Grown By Day")
            .MapToApiVersion(new(1, 0))
            .RequirePerIpRateLimit();

    public async Task<Ok<OrdersGrownByDayDto>> HandleAsync(OrdersGrownByDayRequest request,
        CancellationToken cancellationToken = default)
    {
        OrdersGrownByDayQuery query = new(request.CurrentDate);

        var result = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(result.Value);
    }
}