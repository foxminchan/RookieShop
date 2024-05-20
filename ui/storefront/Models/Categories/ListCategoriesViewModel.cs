using Ardalis.Result;
using RookieShop.Domain.Entities.CategoryAggregator;
using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Models.Categories;

public sealed class ListCategoriesViewModel
{
    [JsonPropertyName("pagedInfo")] public PagedInfo PagedInfo { get; set; } = default!;

    [JsonPropertyName("categories")] public List<Category> Categories { get; set; } = [];
}