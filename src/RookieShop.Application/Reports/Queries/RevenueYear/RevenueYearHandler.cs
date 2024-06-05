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
                                to_char(o.created_date, 'Mon') AS month, 
                                SUM(od.price * od.quantity) AS revenue  
                              FROM orders o
                              JOIN order_details od ON o.id = od.order_id
                              WHERE EXTRACT(YEAR FROM o.created_date) = @year 
                              GROUP BY to_char(o.created_date, 'Mon')  
                            )
                            SELECT 
                              month_names.month AS {nameof(RevenueYearDto.Month)},
                              COALESCE(monthly_revenue.revenue, 0) AS {nameof(RevenueYearDto.Revenue)}
                            FROM (
                              VALUES ('Jan'), ('Feb'), ('Mar'), ('Apr'), ('May'), ('Jun'), 
                                     ('Jul'), ('Aug'), ('Sep'), ('Oct'), ('Nov'), ('Dec')
                            ) AS month_names(month)
                            LEFT JOIN monthly_revenue ON month_names.month = monthly_revenue.month
                            ORDER BY month_names.month;
                            """;

        using var conn = factory.GetOpenConnection();

        var result = await conn.QueryAsync<RevenueYearDto>(sql,
            new { year = request.Year });

        return result.ToList();
    }
}