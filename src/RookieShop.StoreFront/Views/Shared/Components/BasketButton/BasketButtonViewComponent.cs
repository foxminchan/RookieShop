using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Basket.Services;

namespace RookieShop.Storefront.Views.Shared.Components.BasketButton;

[ViewComponent]
public sealed class BasketButtonViewComponent(
    IBasketService basketService,
    IHttpContextAccessor httpContextAccessor) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var context = httpContextAccessor.HttpContext!;
        var userId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        int count;

        if (context.Items.TryGetValue("BasketCount", out var cachedCount)) return View((int)(cachedCount ?? 0));

        try
        {
            var basket = await basketService.GetBasketAsync(Guid.Parse(userId!));

            count = basket.BasketDetails.Count;
        }
        catch (HttpRequestException)
        {
            count = 0;
        }

        context.Items["BasketCount"] = count;

        return View(count);
    }
}