using Refit;

namespace RookieShop.Storefront.Areas.Basket.Models;

public sealed class DeleteItemRequest
{
    [AliasAs("accountId")] public Guid AccountId { get; set; }

    [AliasAs("productId")] public Guid ProductId { get; set; }
}