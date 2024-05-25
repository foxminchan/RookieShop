using System.Text.Json.Serialization;
using RookieShop.Storefront.Areas.Basket.Models;

namespace RookieShop.Storefront.Areas.Order.Models;

public sealed class OrderViewModel
{
    [JsonPropertyName("id")] public Guid Id { get; set; }

    [JsonPropertyName("paymentMethod")] public PaymentMethod PaymentMethod { get; set; }

    [JsonPropertyName("last4")] public string? Last4 { get; set; }

    [JsonPropertyName("brand")] public string? Brand { get; set; }

    [JsonPropertyName("chargeId")] public string? ChargeId { get; set; }

    [JsonPropertyName("street")] public string? Street { get; set; }

    [JsonPropertyName("city")] public string? City { get; set; }

    [JsonPropertyName("province")] public string? Province { get; set; }

    [JsonPropertyName("totalPrice")] public decimal TotalPrice { get; set; }

    [JsonPropertyName("customerId")] public Guid CustomerId { get; set; }

    [JsonPropertyName("status")] public OrderStatus Status { get; set; }

    [JsonPropertyName("createdDate")] public DateTime CreatedDate { get; set; }

    [JsonPropertyName("items")] public List<OrderItemViewModel> Items { get; set; } = [];
}