using System.Text.Json.Serialization;
using Ardalis.Result;

namespace RookieShop.Storefront.Models;

public class BaseListItemViewModel
{
    [JsonPropertyName("pagedInfo")] public PagedInfo PagedInfo { get; set; } = default!;
}