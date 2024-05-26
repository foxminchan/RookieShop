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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddToBasket(BasketRequest basketRequest)
    {
        if (!ModelState.IsValid)
            return RedirectToActionPermanent("Detail", "Product", new { id = basketRequest.ProductId });

        if (basketRequest.AccountId is null) return Unauthorized();

        await basketService.AddToBasketAsync(basketRequest, Guid.NewGuid());

        return RedirectToAction("Detail", "Product", new { id = basketRequest.ProductId, area = "Product" });
    }
}