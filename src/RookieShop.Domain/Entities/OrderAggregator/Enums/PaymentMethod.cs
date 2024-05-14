using System.Text.Json.Serialization;

namespace RookieShop.Domain.Entities.OrderAggregator.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PaymentMethod : byte
{
    Cash = 1,
    Card = 2
}