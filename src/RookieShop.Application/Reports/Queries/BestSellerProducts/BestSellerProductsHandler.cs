using Ardalis.Result;
using Dapper;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Domain.SharedKernel;
using RookieShop.Persistence;

namespace RookieShop.Application.Reports.Queries.BestSellerProducts;

public sealed class BestSellerProductsHandler(IDatabaseFactory factory)
    : IQueryHandler<BestSellerProductsQuery, Result<IEnumerable<BestSellerProductsDto>>>
{
    public async Task<Result<IEnumerable<BestSellerProductsDto>>> Handle(BestSellerProductsQuery request,
        CancellationToken cancellationToken)
    {
        const string sql = $"""
                            SELECT 
                                p.id AS {nameof(BestSellerProductsDto.ProductId)}, 
                                p.name AS {nameof(BestSellerProductsDto.ProductName)}, 
                                p.image_name AS {nameof(BestSellerProductsDto.ImageUrl)}, 
                                SUM(od.quantity) AS {nameof(BestSellerProductsDto.TotalSoldQuantity)},
                                p.price->>'price_sale' AS {nameof(BestSellerProductsDto.PriceSale)},
                                p.price->>'price' AS {nameof(BestSellerProductsDto.Price)}
                            FROM products p
                                JOIN order_details od ON p.id = od.product_id
                                JOIN orders o ON od.order_id = o.id
                            WHERE (@From IS NULL OR o.order_date >= @From)
                                AND (@To IS NULL OR o.order_date <= @To) 
                                AND o.order_status = 1
                            GROUP BY p.id, p.name, p.image_name, p.price
                            ORDER BY {nameof(BestSellerProductsDto.TotalSoldQuantity)} DESC
                            LIMIT @Top;
                            """;

        using var conn = factory.GetOpenConnection();

        var result = await conn.QueryAsync<BestSellerProductsDto>(sql, new { request.From, request.To, request.Top });

        return result.ToList();
    }
}