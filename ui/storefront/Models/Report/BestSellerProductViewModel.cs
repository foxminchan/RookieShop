using RookieShop.Storefront.Areas.Product.Models.Products;

namespace RookieShop.Storefront.Models.Report;

public sealed class BestSellerProductViewModel : BestSellerProduct
{
    public ProductPrice? Price { get; set; } 
}