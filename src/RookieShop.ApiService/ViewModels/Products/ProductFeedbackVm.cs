using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;

namespace RookieShop.ApiService.ViewModels.Products;

public sealed record ProductFeedbackVm(
    FeedbackId Id,
    int Rating,
    string? Content,
    CustomerId? CustomerId);