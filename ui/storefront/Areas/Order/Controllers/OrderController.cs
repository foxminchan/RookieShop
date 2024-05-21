using Microsoft.AspNetCore.Mvc;

namespace RookieShop.Storefront.Areas.Order.Controllers;

public class OrderController : Controller
{
    public IActionResult Index() => View();
}