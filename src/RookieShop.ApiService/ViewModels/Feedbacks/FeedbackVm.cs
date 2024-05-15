using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.ApiService.ViewModels.Feedbacks;

public sealed record FeedbackVm(
    FeedbackId Id,
    ProductId ProductId,
    int Rating,
    string? Content,
    CustomerId? CustomerId);