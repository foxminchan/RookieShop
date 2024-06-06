using Refit;

namespace RookieShop.Storefront.Areas.Product.Models.Products;

public sealed class ProductInfo
{
    [AliasAs("id")] public Guid Id { get; set; }

    [AliasAs("quantity")] public int Quantity { get; set; }
}