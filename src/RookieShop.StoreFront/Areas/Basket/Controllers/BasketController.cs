using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Basket.Models;
using RookieShop.Storefront.Areas.Basket.Services;
using RookieShop.Storefront.Areas.User.Models;

namespace RookieShop.Storefront.Areas.Basket.Controllers;

[Authorize]
[Area("Basket")]
public class BasketController(IBasketService basketService) : Controller
{
    public async Task<IActionResult> Index()
    {
        if (HttpContext.Items["Customer"] is not CustomerViewModel customer) return Unauthorized();

        try
        {
            var basket = await basketService.GetBasketAsync(customer.AccountId);

            return View(basket);
        }
        catch (HttpRequestException)
        {
            return View(null);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddToBasket(BasketRequest basketRequest)
    {
        if (!ModelState.IsValid)
            return RedirectToActionPermanent("Detail", "Product", new { id = basketRequest.ProductId });

        if (basketRequest.AccountId is null) return Unauthorized();

        await basketService.AddToBasketAsync(basketRequest, Guid.NewGuid());

        var count = HttpContext.Items.TryGetValue("BasketCount", out var cachedCount) ? (int)(cachedCount ?? 0) : 0;
        HttpContext.Items["BasketCount"] = count + 1;

        return RedirectToAction("Detail", "Product", new { id = basketRequest.ProductId, area = "Product" });
    }

    public async Task<IActionResult> DeleteItem()
    {
        if (!ModelState.IsValid)
            return RedirectToAction("Index");

        if (!Guid.TryParse(RouteData.Values["id"]?.ToString(), out var productId))
            return RedirectToAction("Index");

        if (HttpContext.Items["Customer"] is not CustomerViewModel customer) return Unauthorized();

        await basketService.DeleteItemAsync(new()
        {
            AccountId = customer.AccountId,
            ProductId = productId
        });

        var count = HttpContext.Items.TryGetValue("BasketCount", out var cachedCount) ? (int)(cachedCount ?? 0) : 0;
        HttpContext.Items["BasketCount"] = count - 1;

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBasket(UpdateBasketQuantityRequest request)
    {
        if (!ModelState.IsValid)
            return RedirectToAction("Index");

        if (HttpContext.Items["Customer"] is not CustomerViewModel customer) return Unauthorized();

        request.AccountId = customer.AccountId;

        await basketService.UpdateBasketAsync(request, Guid.NewGuid());

        return RedirectToAction("Index");
    }
}