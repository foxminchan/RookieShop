using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Application.Reports.Queries.RevenueYear;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Reports;

public sealed class RevenueYear(ISender sender) : IEndpoint<Ok<List<RevenueYearDto>>, RevenueYearRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/reports/revenue-year", async (int year) => await HandleAsync(new(year)))
            .Produces<Ok<List<RevenueYearDto>>>()
            .WithTags(nameof(Reports))
            .WithName("Revenue Year")
            .MapToApiVersion(new(1, 0))
            .RequirePerIpRateLimit();

    public async Task<Ok<List<RevenueYearDto>>> HandleAsync(RevenueYearRequest request,
        CancellationToken cancellationToken = default)
    {
        RevenueYearQuery query = new(request.Year);

        var result = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(result.Value.ToList());
    }
}