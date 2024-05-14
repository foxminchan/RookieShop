using Ardalis.Result;
using RookieShop.Application.Products.DTOs;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Products.Queries.GetBySemanticRelevance;

public sealed record GetBySemanticRelevanceQuery(int PageIndex, int PageSize, string Text)
    : IQuery<PagedResult<IEnumerable<ProductDto>>>;