using Ardalis.Result;
using RookieShop.ApiService.ViewModels.Categories;

namespace RookieShop.ApiService.Endpoints.Categories;

public sealed class ListCategoriesResponse
{
    public PagedInfo? PagedInfo { get; set; }
    public List<CategoryVm>? Categories { get; set; } = [];
}