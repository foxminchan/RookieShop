using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Areas.Order.Models;

public sealed class OrderCreatedResponse
{
    [JsonPropertyName("id")] public Guid OrderId { get; set; }
}