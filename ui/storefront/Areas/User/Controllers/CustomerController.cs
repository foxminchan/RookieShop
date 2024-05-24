using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.User.Models;
using RookieShop.Storefront.Areas.User.Services;

namespace RookieShop.Storefront.Areas.User.Controllers;

[Area("User")]
public class CustomerController(ICustomerService customerService) : Controller
{
    public IActionResult Index() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateCustomerAsync(CustomerRequest request)
    {
        if (!ModelState.IsValid)
            return View("Index", request);

        await customerService.CreateCustomerAsync(request, Guid.NewGuid());

        return RedirectToAction("Index", "Home");
    }
}