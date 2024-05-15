using Ardalis.Result;
using RookieShop.ApiService.ViewModels.Products;

namespace RookieShop.ApiService.Endpoints.Products;

public sealed class ListProductsResponse
{
    public PagedInfo? PagedInfo { get; set; }
    public List<ProductVm>? Products { get; set; } = [];
}