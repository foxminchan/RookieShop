using RookieShop.Domain.Entities.CustomerAggregator.Primitives;

namespace RookieShop.Application.Feedbacks.DTOs;

public sealed record FeedbackCustomerDto(
    CustomerId CustomerId,
    string? CustomerName);
