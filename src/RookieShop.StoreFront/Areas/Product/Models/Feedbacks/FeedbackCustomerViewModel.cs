using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Areas.Product.Models.Feedbacks;

public sealed class FeedbackCustomerViewModel
{
    [JsonPropertyName("customerId")] public Guid Id { get; set; }

    [JsonPropertyName("customerName")] public string Name { get; set; } = default!;
}