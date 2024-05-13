using Ardalis.Result;
using RookieShop.Application.Categories.DTOs;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Categories.Queries.Get;

public sealed record GetCategoryQuery(CategoryId Id) : IQuery<Result<CategoryDto>>;