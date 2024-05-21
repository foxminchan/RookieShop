using Microsoft.AspNetCore.Mvc;

namespace RookieShop.Storefront.Areas.User.Controllers;

public class UserController : Controller
{
    public IActionResult Index() => View();
}