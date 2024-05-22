using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;

namespace RookieShop.Storefront.Areas.User.Controllers;

[Area("User")]
public class AccountController : Controller
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
}