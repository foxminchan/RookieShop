using System.Security.Claims;
using RookieShop.Storefront.Areas.User.Services;

namespace RookieShop.Storefront.Middlewares;

public sealed class CustomerInfoMiddleware(
    RequestDelegate next,
    IHttpContextAccessor httpContextAccessor,
    ICustomerService customerService)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        if (!httpContext.User.Identity!.IsAuthenticated)
        {
            await next(httpContext);
            return;
        }

        var userId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            await next(httpContext);
            return;
        }

        var customer = await customerService.GetCustomerByAccountAsync(Guid.Parse(userId));

        if (customer is null) httpContext.Response.Redirect("/User/Customer");

        await next(httpContext);
    }
}