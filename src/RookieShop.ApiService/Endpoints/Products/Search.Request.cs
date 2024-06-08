namespace RookieShop.ApiService.Endpoints.Products;

public sealed record SearchProductRequest(
    string Context,
    int PageIndex,
    int PageSize);