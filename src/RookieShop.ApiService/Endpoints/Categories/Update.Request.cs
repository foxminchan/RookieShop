using RookieShop.Domain.Entities.CategoryAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Categories;

public sealed class UpdateCategoryRequest
{
    public CategoryId Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}