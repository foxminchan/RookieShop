using RookieShop.Domain.Entities.CategoryAggregator;
using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Models.Categories;

public sealed class ListCategoriesViewModel : BaseListItemViewModel
{
    [JsonPropertyName("categories")] public List<Category> Categories { get; set; } = [];
}