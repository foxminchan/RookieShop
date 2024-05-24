using Microsoft.AspNetCore.Mvc;

namespace RookieShop.Storefront.Areas.Basket.Controllers;

[Area("Basket")]
public class BasketController : Controller
{
    public IActionResult Index() => View();
}