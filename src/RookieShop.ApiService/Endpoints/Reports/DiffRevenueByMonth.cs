using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Application.Reports.Queries.DiffRevenueByMonth;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Reports;

public sealed class DiffRevenueByMonth(ISender sender) : IEndpoint<Ok<DiffRevenueByMonthDto>, DiffRevenueByMonthRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/reports/diff-revenue-by-month",
                async (int sourceMonth, int sourceYear, int targetMonth, int targetYear) =>
                    await HandleAsync(new(sourceMonth, sourceYear, targetMonth, targetYear)))
            .Produces<Ok<DiffRevenueByMonthDto>>()
            .WithTags(nameof(Reports))
            .WithName("Diff Revenue By Month")
            .MapToApiVersion(new(1, 0))
            .RequirePerIpRateLimit();

    public async Task<Ok<DiffRevenueByMonthDto>> HandleAsync(DiffRevenueByMonthRequest request,
        CancellationToken cancellationToken = default)
    {
        DiffRevenueByMonthQuery query = new(
            request.SourceMonth,
            request.SourceYear,
            request.TargetMonth,
            request.TargetYear);

        var result = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(result.Value);
    }
}