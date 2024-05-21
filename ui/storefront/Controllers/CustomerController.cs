using Microsoft.AspNetCore.Mvc;

namespace RookieShop.Storefront.Controllers;

public class CustomerController : Controller
{
    public IActionResult Index() => View();
}