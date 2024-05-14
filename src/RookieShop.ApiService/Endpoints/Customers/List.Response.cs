using Ardalis.Result;
using RookieShop.ApiService.ViewModels.Customers;

namespace RookieShop.ApiService.Endpoints.Customers;

public sealed class ListCustomersResponse
{
    public PagedInfo? PagedInfo { get; set; }
    public List<CustomerVm>? Customers { get; set; } = [];
}