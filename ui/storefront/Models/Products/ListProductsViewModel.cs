using System.Text.Json.Serialization;
using Ardalis.Result;

namespace RookieShop.Storefront.Models.Products;

public sealed class ListProductsViewModel
{
    [JsonPropertyName("pagedInfo")] public PagedInfo PagedInfo { get; set; } = default!;

    [JsonPropertyName("products")] public List<ProductViewModel> Products { get; set; } = [];
}