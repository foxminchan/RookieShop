using RookieShop.Domain.Entities.CategoryAggregator;

namespace RookieShop.Application.Categories.DTOs;

public static class DomainToDtoMapper
{
    public static CategoryDto ToCategoryDto(this Category category) =>
        new(category.Id, category.Name, category.Description);

    public static IEnumerable<CategoryDto> ToCategoryDto(this IEnumerable<Category> categories) =>
        categories.Select(ToCategoryDto);
}