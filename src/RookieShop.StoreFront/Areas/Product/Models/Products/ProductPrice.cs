using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Areas.Product.Models.Products;

public sealed class ProductPrice
{
    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("priceSale")]
    public decimal? PriceSale { get; set; }
}