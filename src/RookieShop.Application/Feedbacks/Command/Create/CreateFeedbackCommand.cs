using Ardalis.Result;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Feedbacks.Command.Create;

public sealed record CreateFeedbackCommand(ProductId ProductId, int Rating, string? Content, CustomerId? CustomerId)
    : ICommand<Result<FeedbackId>>;