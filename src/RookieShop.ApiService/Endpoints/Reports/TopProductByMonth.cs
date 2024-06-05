using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Application.Reports.Queries.TopProductByMonth;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Reports;

public sealed class TopProductByMonth(ISender sender)
    : IEndpoint<Ok<List<TopProductByMonthDto>>, TopProductByMonthRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/reports/top-product-by-month",
                async (int month, int year, int limit) => await HandleAsync(new(month, year, limit)))
            .Produces<Ok<List<TopProductByMonthDto>>>()
            .WithTags(nameof(Reports))
            .WithName("Top Product By Month")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<Ok<List<TopProductByMonthDto>>> HandleAsync(TopProductByMonthRequest request,
        CancellationToken cancellationToken = default)
    {
        TopProductByMonthQuery query = new(
            request.Month,
            request.Year,
            request.Limit);

        var result = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(result.Value.ToList());
    }
}