using Ardalis.Result;
using Dapper;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Domain.SharedKernel;
using RookieShop.Persistence;

namespace RookieShop.Application.Reports.Queries.OrdersGrownByDay;

public sealed class OrdersGrownByDayHandler(IDatabaseFactory factory)
    : IQueryHandler<OrdersGrownByDayQuery, Result<OrdersGrownByDayDto>>
{
    public async Task<Result<OrdersGrownByDayDto>> Handle(OrdersGrownByDayQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = $"""
                            WITH orders_by_day AS (
                                SELECT 
                                    DATE_TRUNC('day', o.created_date AT TIME ZONE 'UTC') AS order_date,
                                    COUNT(*) AS order_count
                                FROM orders o 
                                GROUP BY order_date
                            ),
                            today_orders AS (
                                SELECT order_count AS today_count
                                FROM orders_by_day
                                WHERE order_date = DATE_TRUNC('day', @CurrentDate)
                            ),
                            yesterday_orders AS (
                                SELECT order_count AS yesterday_count
                                FROM orders_by_day
                                WHERE order_date = DATE_TRUNC('day', @CurrentDate) - INTERVAL '1 day'
                            )
                            SELECT 
                                COALESCE(today_orders.today_count, 0) AS {nameof(OrdersGrownByDayDto.TodayCount)},
                                COALESCE(yesterday_orders.yesterday_count, 0) AS {nameof(OrdersGrownByDayDto.YesterdayCount)},
                                CASE 
                                    WHEN COALESCE(yesterday_orders.yesterday_count, 0) = 0 THEN 0
                                    ELSE (COALESCE(today_orders.today_count, 0) - COALESCE(yesterday_orders.yesterday_count, 0)) / COALESCE(yesterday_orders.yesterday_count, 0)::decimal * 100
                                END AS {nameof(OrdersGrownByDayDto.GrowthPercentage)},
                                DATE_TRUNC('day', @CurrentDate) AS {nameof(OrdersGrownByDayDto.CurrentDate)}
                            FROM 
                                (SELECT 1) AS dummy
                            LEFT JOIN today_orders ON TRUE
                            LEFT JOIN yesterday_orders ON TRUE;
                            """;

        using var conn = factory.GetOpenConnection();

        var result = await conn.QueryAsync<OrdersGrownByDayDto>(sql,
            new { request.CurrentDate });

        return result.First();
    }
}