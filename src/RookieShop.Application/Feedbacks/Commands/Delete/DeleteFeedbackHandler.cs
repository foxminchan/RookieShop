using Ardalis.GuardClauses;
using Ardalis.Result;
using RookieShop.Domain.Entities.FeedbackAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Feedbacks.Commands.Delete;

public sealed class DeleteFeedbackHandler(IRepository<Feedback> repository)
    : ICommandHandler<DeleteFeedbackCommand, Result>
{
    public async Task<Result> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = await repository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, feedback);

        await repository.DeleteAsync(feedback, cancellationToken);

        return Result.Success();
    }
}