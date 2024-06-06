using RookieShop.Application.Products.Queries.CheckStock;

namespace RookieShop.ApiService.Endpoints.Products;

public sealed record CheckStockRequest(List<ProductInfo> Requests);