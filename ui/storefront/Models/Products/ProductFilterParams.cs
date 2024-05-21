using Refit;

namespace RookieShop.Storefront.Models.Products;

public sealed class ProductFilterParams : FilterParams
{
    [AliasAs("categoryIds")] public Guid[]? CategoryIds { get; set; } = [];
}