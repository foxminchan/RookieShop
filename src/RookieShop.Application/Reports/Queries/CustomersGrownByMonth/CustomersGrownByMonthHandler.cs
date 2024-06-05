using Ardalis.Result;
using Dapper;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Domain.SharedKernel;
using RookieShop.Persistence;

namespace RookieShop.Application.Reports.Queries.CustomersGrownByMonth;

public sealed class CustomersGrownByMonthHandler(IDatabaseFactory factory)
    : IQueryHandler<CustomersGrownByMonthQuery, Result<CustomersGrownByMonthDto>>
{
    public async Task<Result<CustomersGrownByMonthDto>> Handle(CustomersGrownByMonthQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = $"""
                            WITH current_month AS (
                                SELECT 
                                    COUNT(c.id) AS customer_count
                                FROM 
                                    customers c 
                                WHERE 
                                    EXTRACT(MONTH FROM c.created_date) = @Month 
                                    AND EXTRACT(YEAR FROM c.created_date) = @Year
                            ),
                            previous_month AS (
                                SELECT 
                                    COUNT(c.id) AS customer_count
                                FROM 
                                    customers c 
                                WHERE 
                                    (EXTRACT(MONTH FROM c.created_date) = @Month - 1 
                                    AND EXTRACT(YEAR FROM c.created_date) = @Year)
                                    OR
                                    (EXTRACT(MONTH FROM c.created_date) = 12 
                                    AND EXTRACT(YEAR FROM c.created_date) = @Year - 1
                                    AND @Month = 1)
                            )
                            SELECT 
                                current_month.customer_count AS {nameof(CustomersGrownByMonthDto.CurrentTotalCustomers)},
                                COALESCE(previous_month.customer_count, 0) AS {nameof(CustomersGrownByMonthDto.PreviousTotalCustomers)},
                                current_month.customer_count - COALESCE(previous_month.customer_count, 0) AS {nameof(CustomersGrownByMonthDto.GrownCustomers)}
                            FROM 
                                current_month,
                                previous_month;
                            """;

        using var conn = factory.GetOpenConnection();

        var result = await conn.QueryAsync<CustomersGrownByMonthDto>(sql,
            new { request.Month, request.Year });

        return result.First();
    }
}