namespace RookieShop.ApiService.Endpoints.Reports;

public sealed record BestSellerProductsRequest(int Top, DateTime? From, DateTime? To);