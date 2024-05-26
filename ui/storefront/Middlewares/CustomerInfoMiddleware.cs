using System.Security.Claims;
using RookieShop.Storefront.Areas.User.Models;
using RookieShop.Storefront.Areas.User.Services;

namespace RookieShop.Storefront.Middlewares;

public sealed class CustomerInfoMiddleware(IHttpContextAccessor httpContextAccessor, ICustomerService customerService)
    : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!context.User.Identity!.IsAuthenticated)
        {
            await next(context);
            return;
        }

        var userId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            await next(context);
            return;
        }

        if (context.Items.ContainsKey("Customer"))
        {
            await next(context);
            return;
        }

        CustomerViewModel? customer;

        try
        {
            customer = await customerService.GetCustomerByAccountAsync(Guid.Parse(userId));
        }
        catch (Exception)
        {
            customer = null;
        }

        if (customer is null) context.Response.Redirect("/User/Customer");

        context.Items["Customer"] = customer;

        await next(context);
    }
}