using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Areas.Product.Models.Feedbacks;

public sealed class FeedbackViewModel
{
    [JsonPropertyName("id")] public Guid Id { get; set; }

    [JsonPropertyName("productId")] public Guid ProductId { get; set; }

    [JsonPropertyName("rating")] public int Rating { get; set; }

    [JsonPropertyName("content")] public string? Content { get; set; }

    [JsonPropertyName("updatedDate")] public DateTime UpdatedDate { get; set; }

    [JsonPropertyName("customer")] public FeedbackCustomerViewModel? Customer { get; set; }
}