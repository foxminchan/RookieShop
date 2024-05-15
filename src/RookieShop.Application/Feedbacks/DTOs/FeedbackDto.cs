using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.Application.Feedbacks.DTOs;

public sealed record FeedbackDto(
    FeedbackId Id,
    ProductId ProductId,
    int Rating,
    string? Content,
    CustomerId? CustomerId);