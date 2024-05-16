using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;

namespace RookieShop.Application.Products.DTOs;

public sealed record ProductFeedbackDto(
    FeedbackId Id,
    int Rating,
    string? Content,
    CustomerId? CustomerId);