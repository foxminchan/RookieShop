using Ardalis.Result;
using RookieShop.Application.Feedbacks.DTOs;
using RookieShop.Domain.Entities.FeedbackAggregator;
using RookieShop.Domain.Entities.FeedbackAggregator.Specifications;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Feedbacks.Queries.List;

public sealed class ListFeedbackHandler(IReadRepository<Feedback> repository)
    : IQueryHandler<ListFeedbackQuery, PagedResult<IEnumerable<FeedbackDto>>>
{
    public async Task<PagedResult<IEnumerable<FeedbackDto>>> Handle(ListFeedbackQuery request,
        CancellationToken cancellationToken)
    {
        FeedbackFilterSpec spec = new(
            request.PageIndex,
            request.PageSize,
            request.OrderBy,
            request.IsDescending,
            request.ProductId,
            request.CustomerId);

        var feedbacks = await repository.ListAsync(spec, cancellationToken);

        var totalRecords = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);

        PagedInfo pagedInfo = new(request.PageIndex, request.PageSize, totalPages, totalRecords);

        return new(pagedInfo, feedbacks.ToFeedbackDto());
    }
}