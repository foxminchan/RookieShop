using Refit;

namespace RookieShop.Storefront.Models;

public class PaginatedParams
{
    [AliasAs("pageNumber")] public int PageNumber { get; set; } = 1;

    [AliasAs("pageSize")] public int PageSize { get; set; } = 20;
}