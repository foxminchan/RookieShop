using Ardalis.Result;
using RookieShop.Application.Feedbacks.DTOs;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Feedbacks.Command.Update;

public sealed record UpdateFeedbackCommand(
    FeedbackId Id,
    ProductId ProductId,
    int Rating,
    string? Content,
    CustomerId? CustomerId) : ICommand<Result<FeedbackDto>>;