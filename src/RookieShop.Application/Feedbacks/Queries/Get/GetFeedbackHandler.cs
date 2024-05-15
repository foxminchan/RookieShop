using Ardalis.GuardClauses;
using Ardalis.Result;
using RookieShop.Application.Feedbacks.DTOs;
using RookieShop.Domain.Entities.FeedbackAggregator;
using RookieShop.Domain.Entities.FeedbackAggregator.Specifications;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Feedbacks.Queries.Get;

public sealed class GetFeedbackHandler(IReadRepository<Feedback> repository)
    : IQueryHandler<GetFeedbackQuery, Result<FeedbackDto>>
{
    public async Task<Result<FeedbackDto>> Handle(GetFeedbackQuery request, CancellationToken cancellationToken)
    {
        FeedbackByIdSpec spec = new(request.Id);

        var feedback = await repository.FirstOrDefaultAsync(spec, cancellationToken);

        Guard.Against.NotFound(request.Id, feedback);

        return feedback.ToFeedbackDto();
    }
}