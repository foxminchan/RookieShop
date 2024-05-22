using Refit;
using RookieShop.Storefront.Models;

namespace RookieShop.Storefront.Areas.Product.Models.Products;

public sealed class ProductFilterParams : FilterParams
{
    [AliasAs("categoryIds")] public Guid[]? CategoryIds { get; set; } = [];
}