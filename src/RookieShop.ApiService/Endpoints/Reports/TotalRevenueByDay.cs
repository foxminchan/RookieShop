using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Application.Reports.Queries.TotalRevenueByDay;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Reports;

public sealed class TotalRevenueByDay(ISender sender) : IEndpoint<Ok<TotalRevenueByDayDto>, TotalRevenueByDayRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/reports/total-revenue-by-day",
                async (DateTime? currentDate) => await HandleAsync(new()
                {
                    CurrentDate = currentDate ?? DateTime.Now
                }))
            .Produces<Ok<TotalRevenueByDayDto>>()
            .WithTags(nameof(Reports))
            .WithName("Total Revenue By Day")
            .MapToApiVersion(new(1, 0))
            .RequirePerIpRateLimit();

    public async Task<Ok<TotalRevenueByDayDto>> HandleAsync(TotalRevenueByDayRequest request,
        CancellationToken cancellationToken = default)
    {
        TotalRevenueByDayQuery query = new(request.CurrentDate);
        var result = await sender.Send(query, cancellationToken);
        return TypedResults.Ok(result.Value);
    }
}