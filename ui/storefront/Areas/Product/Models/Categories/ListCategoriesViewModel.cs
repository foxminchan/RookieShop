using System.Text.Json.Serialization;
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Storefront.Models;

namespace RookieShop.Storefront.Areas.Product.Models.Categories;

public sealed class ListCategoriesViewModel : BaseListItemViewModel
{
    [JsonPropertyName("categories")] public List<Category> Categories { get; set; } = [];
}