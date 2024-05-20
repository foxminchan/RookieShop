namespace RookieShop.Storefront.Models.Products;

public sealed class ProductFilterParams : FilterParams
{
    public Guid[]? CategoryIds { get; set; } = [];
}