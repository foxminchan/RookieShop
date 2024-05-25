using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Basket.Models;
using RookieShop.Storefront.Areas.Product.Services;

namespace RookieShop.Storefront.Areas.Basket.Views.Shared.Components.CartItem;

[ViewComponent]
public sealed class CartItemViewComponent(IProductService productService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(Guid id, int quantity)
    {
        var product = await productService.GetProductByIdAsync(id);

        var totalPrice = product.PriceSale * quantity;

        CartDetailRender cartDetailRender = new()
        {
            Product = product,
            Quantity = quantity,
            TotalPrice = totalPrice
        };

        return View(cartDetailRender);
    }
}