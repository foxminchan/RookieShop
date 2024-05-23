using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Areas.User.Models;

public sealed class CustomerViewModel
{
    [JsonPropertyName("id")] public Guid Id { get; set; }

    [JsonPropertyName("name")] public string? Name { get; set; }

    [JsonPropertyName("email")] public string? Email { get; set; }

    [JsonPropertyName("phone")] public string? Phone { get; set; }

    [JsonPropertyName("gender")] public Gender Gender { get; set; }

    [JsonPropertyName("accountId")] public Guid AccountId { get; set; }
}