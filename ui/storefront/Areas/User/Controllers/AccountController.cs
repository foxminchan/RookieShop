using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.User.Services;
using System.Security.Claims;
using System.Text.Json;
using RookieShop.Storefront.Areas.User.Models;

namespace RookieShop.Storefront.Areas.User.Controllers;

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
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        Response.Redirect(Url.Content("~/"));
    }

    public async Task<IActionResult> Index()
    {
        var customer= HttpContext.Items["Customer"] as CustomerViewModel;

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