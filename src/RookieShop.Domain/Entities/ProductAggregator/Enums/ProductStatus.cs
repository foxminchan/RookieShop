using System.Text.Json.Serialization;

namespace RookieShop.Domain.Entities.ProductAggregator.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProductStatus : byte
{
    InStock = 1,
    OutOfStock = 2
}