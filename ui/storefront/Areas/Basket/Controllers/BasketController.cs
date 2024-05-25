using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        var basket = await basketService.GetBasketAsync(customer.AccountId);

        return View(basket);
    }
}