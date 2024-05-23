using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.User.Services;
using System.Security.Claims;

namespace RookieShop.Storefront.Areas.User.Controllers;

[Area("User")]
public class AccountController(ICustomerService customerService, IHttpContextAccessor httpContextAccessor) : Controller
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
        var userId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
            return RedirectToAction("Login");

        var customer = await customerService.GetCustomerByAccountAsync(Guid.Parse(userId));

        return View(customer);
    }
}