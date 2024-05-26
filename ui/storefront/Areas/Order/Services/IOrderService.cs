using Refit;
using RookieShop.Storefront.Areas.Order.Models;
using RookieShop.Storefront.Constants;

namespace RookieShop.Storefront.Areas.Order.Services;

public interface IOrderService
{
    [Get("/orders")]
    Task<ListOrdersViewModel> ListOrdersAsync([Query] OrderFilterParams filterParams);

    [Get("/orders/{orderId}")]
    Task<OrderViewModel> GetOrderByIdAsync(Guid orderId);

    [Post("/orders")]
    Task<OrderViewModel> CreateOrderAsync(
        OrderRequest orderRequest,
        [Header(HeaderName.IdempotencyKey)] Guid requestId);
}