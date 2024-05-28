namespace RookieShop.ApiService.Endpoints.Categories;

public sealed record ListCategoriesRequest(int PageIndex, int PageSize, string? Search = null);