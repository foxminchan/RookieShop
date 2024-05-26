using System.Text.Json;
using Ardalis.Result;
using Microsoft.Extensions.Logging;
using RookieShop.Domain.Entities.FeedbackAggregator;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Feedbacks.Commands.Create;

public sealed class CreateFeedbackHandler(IRepository<Feedback> repository, ILogger<CreateFeedbackHandler> logger)
    : ICommandHandler<CreateFeedbackCommand, Result<FeedbackId>>
{
    public async Task<Result<FeedbackId>> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
    {
        Feedback feedback = new(request.Content, request.Rating, request.ProductId, request.CustomerId);

        logger.LogInformation("[{Command}] - Creating feedback {@Feedback}", nameof(CreateFeedbackCommand),
            JsonSerializer.Serialize(feedback));

        var result = await repository.AddAsync(feedback, cancellationToken);

        return result.Id;
    }
}