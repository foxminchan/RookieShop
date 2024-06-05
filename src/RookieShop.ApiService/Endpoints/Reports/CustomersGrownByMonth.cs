using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Application.Reports.Queries.CustomersGrownByMonth;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Reports;

public sealed class CustomersGrownByMonth(ISender sender)
    : IEndpoint<Ok<CustomersGrownByMonthDto>, CustomersGrownByMonthRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/reports/customers-grown-by-month",
                async (int month, int year) => await HandleAsync(new(month, year)))
            .Produces<Ok<CustomersGrownByMonthDto>>()
            .WithTags(nameof(Reports))
            .WithName("Customers Grown By Month")
            .MapToApiVersion(new(1, 0))
            .RequirePerIpRateLimit();

    public async Task<Ok<CustomersGrownByMonthDto>> HandleAsync(CustomersGrownByMonthRequest request,
        CancellationToken cancellationToken = default)
    {
        CustomersGrownByMonthQuery query = new(request.Month, request.Year);

        var data = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(data.Value);
    }
}