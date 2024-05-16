using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Feedbacks;

public sealed record ListFeedbackRequest(
    int PageIndex,
    int PageSize,
    string? OrderBy,
    bool IsDescending,
    ProductId? ProductId,
    CustomerId? CustomerId);