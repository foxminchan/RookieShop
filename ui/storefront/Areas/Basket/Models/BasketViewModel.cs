using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Areas.Basket.Models;

public sealed class BasketViewModel
{
    [JsonPropertyName("accountId")] public Guid Id { get; set; }

    [JsonPropertyName("totalPrice")] public decimal TotalPrice { get; set; }

    [JsonPropertyName("basketDetails")] public List<BasketDetailViewModel> BasketDetails { get; set; } = [];
}