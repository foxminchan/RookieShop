using Refit;
using RookieShop.Storefront.Models;

namespace RookieShop.Storefront.Areas.Product.Models.Feedbacks;

public sealed class FeedbackFilterParams : FilterParams
{
    [AliasAs("productId")] public Guid? ProductId { get; set; }

    [AliasAs("customerId")] public Guid? CustomerId { get; set; }
}