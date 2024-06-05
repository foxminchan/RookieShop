using Ardalis.Result;
using Dapper;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Domain.SharedKernel;
using RookieShop.Persistence;

namespace RookieShop.Application.Reports.Queries.TotalRevenueByDay;

public sealed class TotalRevenueByDayHandler(IDatabaseFactory factory)
    : IQueryHandler<TotalRevenueByDayQuery, Result<TotalRevenueByDayDto>>
{
    public async Task<Result<TotalRevenueByDayDto>> Handle(TotalRevenueByDayQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = $"""
                            WITH revenue_data AS (
                                SELECT
                                    o.created_date AS {nameof(TotalRevenueByDayDto.Date)},
                                    SUM(od.price * od.quantity) AS {nameof(TotalRevenueByDayDto.TotalRevenue)}
                                FROM
                                    orders o 
                                JOIN
                                    order_details od ON o.id = od.order_id
                                WHERE
                                    o.created_date::date = (@CurrentDate)::date
                                GROUP BY
                                    o.created_date
                            )
                            SELECT
                                {nameof(TotalRevenueByDayDto.Date)},
                                COALESCE({nameof(TotalRevenueByDayDto.TotalRevenue)}, 0) AS {nameof(TotalRevenueByDayDto.TotalRevenue)}
                            FROM
                                revenue_data
                            UNION ALL
                            SELECT
                                @CurrentDate AS {nameof(TotalRevenueByDayDto.Date)},
                                0 AS {nameof(TotalRevenueByDayDto.TotalRevenue)}
                            WHERE
                                NOT EXISTS (SELECT 1 FROM revenue_data)
                            ORDER BY
                                {nameof(TotalRevenueByDayDto.Date)};
                            """;

        using var conn = factory.GetOpenConnection();

        var result = await conn.QueryAsync<TotalRevenueByDayDto>(sql,
            new { request.CurrentDate });

        return result.First();
    }
}