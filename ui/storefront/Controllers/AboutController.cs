using Microsoft.AspNetCore.Mvc;

namespace RookieShop.Storefront.Controllers;

public class AboutController : Controller
{
    public IActionResult Index() => View();
}