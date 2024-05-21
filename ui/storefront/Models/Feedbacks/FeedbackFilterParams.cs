using Refit;

namespace RookieShop.Storefront.Models.Feedbacks;

public sealed class FeedbackFilterParams : FilterParams
{
    [AliasAs("productId")] public Guid? ProductId { get; set; }

    [AliasAs("customerId")] public Guid? CustomerId { get; set; }
}