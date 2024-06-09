using Refit;
using RookieShop.Storefront.Models;

namespace RookieShop.Storefront.Areas.Product.Models.Products;

public sealed class ProductSearchParams : PaginatedParams
{
    [AliasAs("context")] public string? Context { get; set; } = null;
}