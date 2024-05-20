using System.Text.Json.Serialization;
using RookieShop.Storefront.Models.Categories;

namespace RookieShop.Storefront.Models.Products;

public sealed class ProductViewModel
{
    [JsonPropertyName("id")] public Guid Id { get; set; }

    [JsonPropertyName("name")] public string? Name { get; set; }

    [JsonPropertyName("description")] public string? Description { get; set; }

    [JsonPropertyName("quantity")] public int Quantity { get; set; }

    [JsonPropertyName("price")] public decimal Price { get; set; }

    [JsonPropertyName("priceSale")] public decimal PriceSale { get; set; }

    [JsonPropertyName("imageUrl")] public string? ImageUrl { get; set; }

    [JsonPropertyName("category")] public CategoryViewModel? Category { get; set; }

    [JsonPropertyName("feedbacks")] public List<ProductFeedbackViewModel>? Feedbacks { get; set; }
}