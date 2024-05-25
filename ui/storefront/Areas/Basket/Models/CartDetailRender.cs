using RookieShop.Storefront.Areas.Product.Models.Products;

namespace RookieShop.Storefront.Areas.Basket.Models;

public sealed class CartDetailRender
{
    public ProductViewModel Product { get; set; } = new();

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }
}