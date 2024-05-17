using Microsoft.AspNetCore.Mvc;

namespace RookieShop.Storefront.Controllers;

public class ErrorController : Controller
{
    public IActionResult PageNotFound() => View();
}