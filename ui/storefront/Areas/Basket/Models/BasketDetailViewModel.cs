using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Areas.Basket.Models;

public sealed class BasketDetailViewModel
{
    [JsonPropertyName("id")] public Guid Id { get; set; }

    [JsonPropertyName("quantity")] public int Quantity { get; set; }

    [JsonPropertyName("price")] public decimal Price { get; set; }
}