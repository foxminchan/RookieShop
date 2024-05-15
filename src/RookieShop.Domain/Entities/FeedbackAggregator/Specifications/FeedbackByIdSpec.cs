using Ardalis.Specification;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;

namespace RookieShop.Domain.Entities.FeedbackAggregator.Specifications;

public sealed class FeedbackByIdSpec : Specification<Feedback>
{
    public FeedbackByIdSpec(FeedbackId id) => Query.Where(x => x.Id == id);
}