using System.Text.Json.Serialization;

namespace RookieShop.Domain.Entities.OrderAggregator.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderStatus : byte
{
    Pending = 1,
    Shipping = 2,
    Completed = 3,
    Canceled = 4
}