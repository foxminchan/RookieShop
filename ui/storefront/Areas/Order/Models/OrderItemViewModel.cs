using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Areas.Order.Models;

public class OrderItemViewModel
{
    [JsonPropertyName("id")] public Guid Id { get; set; }

    [JsonPropertyName("price")] public decimal Price { get; set; }

    [JsonPropertyName("quantity")] public int Quantity { get; set; }
}