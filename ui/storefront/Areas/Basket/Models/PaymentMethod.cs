using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Areas.Basket.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PaymentMethod : byte
{
    Cash = 1,
    Card = 2
}