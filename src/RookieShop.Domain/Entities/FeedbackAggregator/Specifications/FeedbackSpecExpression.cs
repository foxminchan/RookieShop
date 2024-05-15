using Ardalis.Specification;

namespace RookieShop.Domain.Entities.FeedbackAggregator.Specifications;

public static class FeedbackSpecExpression
{
    public static ISpecificationBuilder<Feedback> ApplyOrdering(this ISpecificationBuilder<Feedback> builder,
        string? orderBy, bool isDescending) =>
        orderBy switch
        {
            nameof(Feedback.Rating) => isDescending
                ? builder.OrderByDescending(feedback => feedback.Rating)
                : builder.OrderBy(feedback => feedback.Rating),
            nameof(Feedback.CreatedDate) => isDescending
                ? builder.OrderByDescending(feedback => feedback.CreatedDate)
                : builder.OrderBy(feedback => feedback.CreatedDate),
            _ => isDescending
                ? builder.OrderByDescending(feedback => feedback.Id)
                : builder.OrderBy(feedback => feedback.Id)
        };

    public static ISpecificationBuilder<Feedback> ApplyPaging(this ISpecificationBuilder<Feedback> builder,
        int pageIndex, int pageSize) =>
        builder
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);
}