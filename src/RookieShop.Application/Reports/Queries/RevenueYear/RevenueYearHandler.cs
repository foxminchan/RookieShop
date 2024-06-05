using Ardalis.Result;
using Dapper;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Domain.SharedKernel;
using RookieShop.Persistence;

namespace RookieShop.Application.Reports.Queries.RevenueYear;

public sealed class RevenueYearHandler(IDatabaseFactory factory)
    : IQueryHandler<RevenueYearQuery, Result<IEnumerable<RevenueYearDto>>>
{
    public async Task<Result<IEnumerable<RevenueYearDto>>> Handle(RevenueYearQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = $"""
                            WITH monthly_revenue AS (
                              SELECT 
                                to_char(o.created_date, 'Mon') AS month_name,
                                SUM(od.price * od.quantity) AS revenue  
                              FROM orders o
                              JOIN order_details od ON o.id = od.order_id
                              WHERE EXTRACT(YEAR FROM o.created_date) = @Year 
                              GROUP BY to_char(o.created_date, 'Mon')
                            )
                            SELECT 
                              month_names.month AS {nameof(RevenueYearDto.Month)},
                              COALESCE(monthly_revenue.revenue, 0) AS {nameof(RevenueYearDto.Revenue)}
                            FROM (
                              VALUES 
                              (1,'Jan'), (2,'Feb'), (3,'Mar'), (4,'Apr'), (5,'May'), (6,'Jun'), 
                              (7,'Jul'), (8,'Aug'), (9,'Sep'), (10,'Oct'), (11,'Nov'), (12,'Dec')
                            ) AS month_names(month_number, month)
                            LEFT JOIN monthly_revenue ON month_names.month = monthly_revenue.month_name
                            ORDER BY month_names.month_number;
                            """;

        using var conn = factory.GetOpenConnection();

        var result = await conn.QueryAsync<RevenueYearDto>(sql,
            new { year = request.Year });

        return result.ToList();
    }
}