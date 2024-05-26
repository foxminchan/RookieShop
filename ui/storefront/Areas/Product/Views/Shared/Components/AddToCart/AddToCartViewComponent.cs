using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Basket.Models;
using System.Security.Claims;

namespace RookieShop.Storefront.Areas.Product.Views.Shared.Components.AddToCart;

[ViewComponent]
public sealed class AddToCartViewComponent(IHttpContextAccessor httpContextAccessor)
    : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(Guid productId, decimal price)
    {
        var userId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        var basketRequest = new BasketRequest
        {
            AccountId = string.IsNullOrEmpty(userId) ? null : Guid.Parse(userId),
            ProductId = productId,
            Price = price,
            Quantity = 1
        };

        return View(basketRequest);
    }
}