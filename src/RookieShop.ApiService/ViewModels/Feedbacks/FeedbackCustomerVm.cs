using RookieShop.Domain.Entities.CustomerAggregator.Primitives;

namespace RookieShop.ApiService.ViewModels.Feedbacks;

public sealed record FeedbackCustomerVm(
    CustomerId CustomerId,
    string? CustomerName);