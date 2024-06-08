using Refit;

namespace RookieShop.Storefront.Models;

public class FilterParams : PaginatedParams
{
    [AliasAs("isDescending")] public bool IsDescending { get; set; } = false;

    [AliasAs("orderBy")] public string? OrderBy { get; set; } = null;
}