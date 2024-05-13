using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;

namespace RookieShop.Application.Categories.DTOs;

public sealed record CategoryDto(CategoryId Id, string Name, string? Description);