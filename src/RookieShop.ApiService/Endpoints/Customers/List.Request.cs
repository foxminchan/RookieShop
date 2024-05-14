namespace RookieShop.ApiService.Endpoints.Customers;

public sealed record ListCustomersRequest(int PageIndex, int PageSize, string? Name);