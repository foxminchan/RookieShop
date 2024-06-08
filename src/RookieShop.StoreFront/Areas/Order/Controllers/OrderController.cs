using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Basket.Models;
using RookieShop.Storefront.Areas.Basket.Services;
using RookieShop.Storefront.Areas.Order.Models;
using RookieShop.Storefront.Areas.Order.Services;
using RookieShop.Storefront.Areas.Product.Models.Products;
using RookieShop.Storefront.Areas.Product.Services;
using RookieShop.Storefront.Areas.User.Models;
using Stripe.Checkout;

namespace RookieShop.Storefront.Areas.Order.Controllers;

[Authorize]
[Area("Order")]
public class OrderController(
    IOrderService orderService,
    IBasketService basketService,
    IProductService productService) : Controller
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
            return View(null);

        var order = await orderService.GetOrderByIdAsync(orderId);

        return View(order);
    }

    public IActionResult CanceledOrder() => View();

    [HttpPost]
    public async Task<IActionResult> CheckOut(OrderFromRequest orderRequest)
    {
        if (!ModelState.IsValid)
            return RedirectToAction("Index", "Basket", new { area = "Basket" });

        if (HttpContext.Items["Customer"] is not CustomerViewModel customer) return Unauthorized();

        var basketItems = await basketService.GetBasketAsync(customer.AccountId);
        var orderItems = await PrepareOrderItems(basketItems);

        if (!await CheckStock(orderItems))
        {
            TempData["Message"] = "Some products are out of stock or removed from the store. Please check your basket again.";
            return RedirectToAction("Index", "Basket", new { area = "Basket" });
        }

        if (orderRequest.PaymentMethod == PaymentMethod.Card)
            return await HandleCardPayment(orderItems, orderRequest, customer);

        var order = new OrderRequest
        {
            AccountId = customer.AccountId,
            PaymentMethod = orderRequest.PaymentMethod,
            Street = orderRequest.Street,
            City = orderRequest.City,
            Province = orderRequest.Province
        };

        var result = await orderService.CreateOrderAsync(order, Guid.NewGuid());
        return RedirectToAction("ConfirmOrder", "Order", new { area = "Order", id = result.OrderId });
    }

    private async Task<bool> CheckStock(List<OrderItemFromRequest> orderItems)
    {
        var checkStockRequest = new CheckStockRequest
        {
            Requests = orderItems.Select(item => new ProductInfo
            {
                Id = item.ProductId,
                Quantity = item.Quantity
            }).ToList()
        };

        var checkStock = await productService.CheckStockAsync(checkStockRequest, Guid.NewGuid());

        return checkStock.IsValid;
    }

    private async Task<List<OrderItemFromRequest>> PrepareOrderItems(BasketViewModel basketItems)
    {
        var orderItems = new List<OrderItemFromRequest>();
        foreach (var item in basketItems.BasketDetails)
        {
            var product = await productService.GetProductByIdAsync(item.Id);
            orderItems.Add(new()
            {
                ProductId = product.Id,
                ProductName = product.Name,
                PriceSale = product.PriceSale,
                Quantity = item.Quantity
            });
        }

        return orderItems;
    }

    private async Task<IActionResult> HandleCardPayment(
        List<OrderItemFromRequest> orderItems,
        OrderFromRequest orderRequest,
        CustomerViewModel customer)
    {
        var domain = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}";
        var sessionOptions = new SessionCreateOptions
        {
            PaymentMethodTypes = ["card"],
            CustomerEmail = customer.Email,
            LineItems = orderItems.Select(item => new SessionLineItemOptions
            {
                PriceData = new()
                {
                    Currency = "usd",
                    ProductData = new()
                    {
                        Name = item.ProductName
                    },
                    UnitAmount = Convert.ToInt64(item.PriceSale * item.Quantity * 100)
                },
                Quantity = item.Quantity,
            }).ToList(),
            Mode = "payment",
            SuccessUrl = domain + "/Order/Order/ConfirmOrder",
            CancelUrl = domain + "/Order/Order/CanceledOrder",
            Metadata = new()
            {
                { "accountId", customer.AccountId.ToString() },
                { "street", orderRequest.Street },
                { "city", orderRequest.City },
                { "province", orderRequest.Province }
            }
        };

        var sessionService = new SessionService();
        var session = await sessionService.CreateAsync(sessionOptions);
        return Redirect(session.Url);
    }
}