using Ardalis.Result;
using RookieShop.ApiService.ViewModels.Orders;

namespace RookieShop.ApiService.Endpoints.Orders;

public sealed class ListOrdersResponse
{
    public PagedInfo? PagedInfo { get; set; }
    public List<OrderVm> Orders { get; set; } = [];
}