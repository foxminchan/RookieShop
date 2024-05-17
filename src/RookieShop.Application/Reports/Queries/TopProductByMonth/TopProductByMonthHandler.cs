using Ardalis.Result;
using Dapper;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Domain.SharedKernel;
using RookieShop.Persistence;

namespace RookieShop.Application.Reports.Queries.TopProductByMonth;

public sealed class TopProductByMonthHandler(IDatabaseFactory factory)
    : IQueryHandler<TopProductByMonthQuery, Result<IEnumerable<TopProductByMonthVm>>>
{
    public async Task<Result<IEnumerable<TopProductByMonthVm>>> Handle(TopProductByMonthQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = $"""
                           SELECT p.id AS {nameof(TopProductByMonthVm.Id)}, 
                           p.name AS {nameof(TopProductByMonthVm.Name)}, 
                           SUM(od.quantity) AS {nameof(TopProductByMonthVm.TotalSoldQuantity)}
                           FROM products AS p
                               INNER JOIN order_details AS od ON p.id = od.product_id
                               INNER JOIN orders AS o ON od.order_id = o.id
                           WHERE o.created_date >= DATE_TRUNC('month', make_date(@Year, @Month, 1))
                               AND o.created_date < DATE_TRUNC('month', make_date(@Year, @Month, 1) + INTERVAL '1 month')
                           GROUP BY p.Id, p.Name
                           ORDER BY TotalQuantity DESC
                           LIMIT @Limit;
                           """;
        using var conn = factory.GetOpenConnection();

        var result =
            await conn.QueryAsync<TopProductByMonthVm>(sql, new { request.Month, request.Year, request.Limit });

        return result.ToList();
    }
}