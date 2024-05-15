using System.Text.Json;
using Ardalis.GuardClauses;
using Ardalis.Result;
using Microsoft.Extensions.Logging;
using RookieShop.Application.Feedbacks.DTOs;
using RookieShop.Domain.Entities.FeedbackAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Feedbacks.Command.Update;

public sealed class UpdateFeedbackHandler(IRepository<Feedback> repository, ILogger<UpdateFeedbackHandler> logger)
    : ICommandHandler<UpdateFeedbackCommand, Result<FeedbackDto>>
{
    public async Task<Result<FeedbackDto>> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = await repository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, feedback);

        feedback.Update(request.Content, request.Rating, request.ProductId, request.CustomerId);

        logger.LogInformation("[{Command}] - Updating feedback: {@Feedback}", nameof(UpdateFeedbackCommand),
            JsonSerializer.Serialize(feedback));

        await repository.UpdateAsync(feedback, cancellationToken);

        return feedback.ToFeedbackDto();
    }
}