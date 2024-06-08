using Ardalis.Result;
using RookieShop.Application.Products.DTOs;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Products.Queries.Search;

public sealed record SearchProductQuery(
    string Context, 
    int PageIndex, 
    int PageSize) : IQuery<PagedResult<IEnumerable<ProductDto>>>;