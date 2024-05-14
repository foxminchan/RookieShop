using System.Text.Json.Serialization;

namespace RookieShop.Domain.Entities.CustomerAggregator.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender : byte
{
    Male = 1,
    Female = 2,
    Other = 3
}