using Ardalis.Result;
using RookieShop.Application.Categories.DTOs;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Categories.Queries.List;

public sealed record ListCategoriesQuery(int PageIndex, int PageSize) : IQuery<PagedResult<IEnumerable<CategoryDto>>>;