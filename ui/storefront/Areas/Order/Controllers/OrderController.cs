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
            CustomerId = customer.Id
        };

        var orders = await orderService.ListOrdersAsync(filterParams);

        return View(orders);
    }

    public async Task<IActionResult> ConfirmOrder()
    {
        if (!ModelState.IsValid)
            return RedirectToAction("Index", "Order", new { area = "Order" });

        if (!Guid.TryParse(RouteData.Values["id"]?.ToString(), out var orderId))
            return BadRequest();

        var order = await orderService.GetOrderByIdAsync(orderId);

        return View(order);
    }

    [HttpPost]
    public async Task<IActionResult> CheckOut(OrderRequest orderRequest)
    {
        if (!ModelState.IsValid)
            return RedirectToAction("Index", "Basket", new { area = "Basket" });

        if (HttpContext.Items["Customer"] is not CustomerViewModel customer) return Unauthorized();

        orderRequest.AccountId = customer.AccountId;

        var result = await orderService.CreateOrderAsync(orderRequest, Guid.NewGuid());

        return RedirectToAction("ConfirmOrder", "Order", new { area = "Order", id = result.OrderId });
    }
}