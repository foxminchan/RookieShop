using Ardalis.Result;
using Dapper;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Domain.SharedKernel;
using RookieShop.Persistence;

namespace RookieShop.Application.Reports.Queries.DiffRevenueByMonth;

public sealed class DiffRevenueByMonthHandler(IDatabaseFactory factory)
    : IQueryHandler<DiffRevenueByMonthQuery, Result<DiffRevenueByMonthDto?>>
{
    public async Task<Result<DiffRevenueByMonthDto?>> Handle(DiffRevenueByMonthQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = $"""
                            WITH MonthYearRevenue AS
                                (
                                SELECT EXTRACT(MONTH FROM o.created_date) AS month,
                                       EXTRACT(YEAR FROM o.created_date)  AS year,
                                       SUM(od.quantity * od.price)        AS total_revenue
                                FROM orders AS o
                                    INNER JOIN order_details AS od ON o.id = od.order_id
                                WHERE (
                                    EXTRACT(YEAR FROM o.created_date) = @SourceYear
                                        AND EXTRACT(MONTH FROM o.created_date) = @SourceMonth
                                    )
                                   OR (
                                       EXTRACT(YEAR FROM o.created_date) = @TargetYear AND
                                       EXTRACT(MONTH FROM o.created_date) = @TargetMonth
                                       )
                                GROUP BY EXTRACT(MONTH FROM o.created_date), EXTRACT(YEAR FROM o.created_date)
                                )
                            SELECT CONCAT(s.month, '/', s.year) AS {nameof(DiffRevenueByMonthDto.SourceMonthYear)},
                                   CONCAT(d.month, '/', d.year) AS {nameof(DiffRevenueByMonthDto.TargetMonthYear)},
                                   ABS(s.total_revenue - d.total_revenue) AS {nameof(DiffRevenueByMonthDto.Diff)}
                            FROM MonthYearRevenue s
                                CROSS JOIN MonthYearRevenue d
                            WHERE s.month = @SourceMonth
                              AND s.year = @SourceYear
                              AND d.month = @TargetMonth
                              AND d.year = @TargetYear;
                            """;

        using var conn = factory.GetOpenConnection();

        var result = await conn.QueryAsync<DiffRevenueByMonthDto>(sql,
            new { request.SourceMonth, request.SourceYear, request.TargetMonth, request.TargetYear });

        return result.FirstOrDefault();
    }
}