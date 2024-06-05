using Microsoft.AspNetCore.Mvc;

namespace RookieShop.Storefront.Controllers;

public class ErrorController : Controller
{
    public IActionResult UnAuthorized() => View();

    public IActionResult NotFoundPage() => View();
}