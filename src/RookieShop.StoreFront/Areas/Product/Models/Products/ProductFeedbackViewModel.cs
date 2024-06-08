using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Areas.Product.Models.Products;

public class ProductFeedbackViewModel
{
    [JsonPropertyName("id")] public Guid Id { get; set; }

    [JsonPropertyName("rating")] public int Rating { get; set; }

    [JsonPropertyName("content")] public string? Content { get; set; }

    [JsonPropertyName("customerId")] public Guid? CustomerId { get; set; }
}