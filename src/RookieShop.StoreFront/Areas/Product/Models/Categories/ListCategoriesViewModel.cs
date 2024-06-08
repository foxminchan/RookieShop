using System.Text.Json.Serialization;
using RookieShop.Storefront.Models;

namespace RookieShop.Storefront.Areas.Product.Models.Categories;

public sealed class ListCategoriesViewModel : BaseListItemViewModel
{
    [JsonPropertyName("categories")] public List<CategoryViewModel> Categories { get; set; } = [];
}