using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.Application.Feedbacks.DTOs;

public sealed record FeedbackDto(
    FeedbackId Id,
    ProductId ProductId,
    int Rating,
    string? Content,
    DateTime? UpdatedDate,
    FeedbackCustomerDto? Customer);