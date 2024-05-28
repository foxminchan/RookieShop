using Ardalis.Specification;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.Domain.Entities.FeedbackAggregator.Specifications;

public sealed class FeedbackFilterSpec : Specification<Feedback>
{
    public FeedbackFilterSpec(int pageIndex, int pageSize, string? orderBy, bool isDescending, ProductId? productId,
        CustomerId? customerId)
    {
        if (pageSize == 0) pageSize = int.MaxValue;

        if (productId is not null)
            Query.Where(feedback => feedback.Product!.Id == productId);

        if (customerId is not null)
            Query.Where(feedback => feedback.CustomerId == customerId);

        Query
            .ApplyPaging(pageIndex, pageSize)
            .ApplyOrdering(orderBy, isDescending);
    }
}