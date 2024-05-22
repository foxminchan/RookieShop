using Microsoft.AspNetCore.Mvc;

namespace RookieShop.Storefront.Areas.User.Controllers;

[Area("User")]
public class CustomerController : Controller
{
    public IActionResult Index() => View();
}