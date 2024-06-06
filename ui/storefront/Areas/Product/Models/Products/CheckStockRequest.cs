using Refit;

namespace RookieShop.Storefront.Areas.Product.Models.Products;

public sealed class CheckStockRequest
{
    [AliasAs("requests")] public List<ProductInfo> Requests { get; set; } = [];
}