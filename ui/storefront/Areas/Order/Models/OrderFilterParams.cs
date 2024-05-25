using Refit;
using RookieShop.Storefront.Models;

namespace RookieShop.Storefront.Areas.Order.Models;

public sealed class OrderFilterParams : PaginatedParams
{
    [AliasAs("status")] public OrderStatus? Status { get; set; }

    [AliasAs("userId")] public Guid? CustomerId { get; set; }
}