using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Areas.Product.Models.Categories;

public sealed class CategoryViewModel
{
    [JsonPropertyName("id")] public Guid Id { get; set; }

    [JsonPropertyName("name")] public string? Name { get; set; }

    [JsonPropertyName("description")] public string? Description { get; set; }
}