using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Models.Report;

public sealed class BestSellerProductResponse : BestSellerProduct
{
    [JsonPropertyName("price")]
    public string Price { get; set; } = string.Empty;
}