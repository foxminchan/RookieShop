using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Models.Feedbacks;

public sealed class FeedbackViewModel
{
    [JsonPropertyName("id")] public Guid Id { get; set; }

    [JsonPropertyName("productId")] public Guid ProductId { get; set; }

    [JsonPropertyName("rating")] public int Rating { get; set; }

    [JsonPropertyName("content")] public string? Content { get; set; }

    [JsonPropertyName("customerId")] public Guid CustomerId { get; set; }
}