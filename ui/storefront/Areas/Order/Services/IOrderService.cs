using Refit;
using RookieShop.Storefront.Areas.Order.Models;

namespace RookieShop.Storefront.Areas.Order.Services;

public interface IOrderService
{
    [Get("/orders")]
    Task<ListOrdersViewModel> ListOrdersAsync([Query] OrderFilterParams filterParams);
}