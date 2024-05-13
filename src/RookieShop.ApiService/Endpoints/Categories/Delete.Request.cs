using RookieShop.Domain.Entities.CategoryAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Categories;

public sealed record DeleteCategoryRequest(CategoryId Id);