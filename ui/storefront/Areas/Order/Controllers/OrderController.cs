using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Order.Models;
using RookieShop.Storefront.Areas.Order.Services;
using RookieShop.Storefront.Areas.User.Models;

namespace RookieShop.Storefront.Areas.Order.Controllers;

[Authorize]
[Area("Order")]
public class OrderController(IOrderService orderService) : Controller
{
    public async Task<IActionResult> Index()
    {
        if (HttpContext.Items["Customer"] is not CustomerViewModel customer) return Unauthorized();

        OrderFilterParams filterParams = new()
        {
            PageNumber = 1,
            CustomerId = customer.AccountId
        };

        var orders = await orderService.ListOrdersAsync(filterParams);

        return View(orders);
    }
}