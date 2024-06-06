using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Areas.Product.Models.Products;

public sealed class CheckStockResponse
{
    [JsonPropertyName("isValid")]
    public bool IsValid { get; set; }
}