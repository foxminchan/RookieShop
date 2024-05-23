using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Basket.Services;

namespace RookieShop.Storefront.Views.Shared.Components.BasketButton;

[ViewComponent]
public sealed class BasketButtonViewComponent(IBasketService basketService, IHttpContextAccessor httpContextAccessor)
    : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        var basket = await basketService.GetBasketAsync(Guid.Parse(userId!));

        var count = basket.BasketDetails.Count;

        return View(count);
    }
}