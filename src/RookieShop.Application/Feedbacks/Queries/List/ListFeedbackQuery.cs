using Ardalis.Result;
using RookieShop.Application.Feedbacks.DTOs;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Feedbacks.Queries.List;

public sealed record ListFeedbackQuery(
    int PageIndex,
    int PageSize,
    string? OrderBy,
    bool IsDescending,
    ProductId? ProductId,
    CustomerId? CustomerId) : IQuery<PagedResult<IEnumerable<FeedbackDto>>>;