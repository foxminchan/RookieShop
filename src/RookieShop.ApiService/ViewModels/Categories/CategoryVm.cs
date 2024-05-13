using RookieShop.Domain.Entities.CategoryAggregator.Primitives;

namespace RookieShop.ApiService.ViewModels.Categories;

public sealed record CategoryVm(CategoryId Id, string Name, string? Description);