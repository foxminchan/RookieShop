using Ardalis.Result;
using RookieShop.Application.Products.DTOs;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Products.Queries.GetByCategory;

public sealed record GetByCategoryQuery(
    int PageIndex,
    int PageSize,
    CategoryId CategoryId,
    string? OrderBy,
    bool IsDescending) : IQuery<PagedResult<IEnumerable<ProductDto>>>;