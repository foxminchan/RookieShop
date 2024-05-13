using Ardalis.Result;
using RookieShop.ApiService.ViewModels.Categories;

namespace RookieShop.ApiService.Endpoints.Categories;

public sealed class ListCategoriesResponse
{
    public PagedInfo? PageInfo { get; set; }
    public List<CategoryVm>? Categories { get; set; } = [];
}