using Ardalis.Result;
using RookieShop.Application.Products.DTOs;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Products.Queries.List;

public sealed record ListProductsQuery(int PageIndex, int PageSize, string? OrderBy, bool IsDescending = false)
    : IQuery<PagedResult<IEnumerable<ProductDto>>>;