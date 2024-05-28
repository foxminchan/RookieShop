using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Areas.Product.Models.Products;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProductStatus : byte
{
    InStock = 1,
    OutOfStock = 2,
    Discontinued = 3
}