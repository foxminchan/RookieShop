using RookieShop.Application.Categories.DTOs;

namespace RookieShop.ApiService.ViewModels.Categories;

public static class DtoToViewModelMapper
{
    public static CategoryVm ToCategoryVm(this CategoryDto categoryDto) =>
        new(categoryDto.Id, categoryDto.Name, categoryDto.Description);

    public static List<CategoryVm> ToCategoryVm(this IEnumerable<CategoryDto> categories) =>
        categories.Select(ToCategoryVm).ToList();
}