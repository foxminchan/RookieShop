using Ardalis.Result;
using Dapper;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Storage.Azurite;
using RookieShop.Persistence;

namespace RookieShop.Application.Reports.Queries.BestSellerProducts;

public sealed class BestSellerProductsHandler(IDatabaseFactory factory, IAzuriteService azuriteService)
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
                            	p.price AS {nameof(BestSellerProductsDto.Price)},
                            	COUNT(od.quantity) AS {nameof(BestSellerProductsDto.TotalSoldQuantity)}
                            FROM products p
                            	JOIN order_details od ON p.id = od.product_id
                            	JOIN orders o ON od.order_id = o.id
                            WHERE o.order_status = 1 
                                AND p.status = 1
                                AND p.is_deleted = false 
                            GROUP BY p.id, p.name, p.image_name, p.price 
                            ORDER BY {nameof(BestSellerProductsDto.TotalSoldQuantity)} DESC
                            LIMIT 5
                            """;

        using var conn = factory.GetOpenConnection();

        var data = await conn.QueryAsync<BestSellerProductsDto>(sql, new { request.Top });

        var result = data.Select(item =>
        {
            item.ImageUrl = azuriteService.GetFileUrl(item.ImageUrl);
            return item;
        }).ToList();

        return result.ToList();
    }
}