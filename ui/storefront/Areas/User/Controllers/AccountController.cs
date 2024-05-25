using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.User.Services;
using RookieShop.Storefront.Areas.User.Models;

namespace RookieShop.Storefront.Areas.User.Controllers;

[Authorize]
[Area("User")]
public class AccountController(ICustomerService customerService) : Controller
{
    public async Task Login()
    {
        if (HttpContext.User.Identity is not null && !HttpContext.User.Identity.IsAuthenticated)
            await HttpContext.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, new()
            {
                RedirectUri = "/"
            });
        else
            Response.Redirect(Url.Content("/"));
    }

    public async Task Logout()
    {
        if (HttpContext.User.Identity is not null && HttpContext.User.Identity.IsAuthenticated)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
            Response.Redirect(Url.Content("/"));
        }
        else
            Response.Redirect(Url.Content("/"));
    }

    public async Task<IActionResult> Index()
    {
        if (HttpContext.Items["Customer"] is not CustomerViewModel customer) return Unauthorized();

        return View(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(CustomerViewModel customer)
    {
        if (!ModelState.IsValid)
            return View("Index", customer);

        await customerService.UpdateCustomerAsync(customer);

        return RedirectToAction("Index");
    }
}