using Ardalis.SmartEnum;

namespace RookieShop.Domain.Entities.ProductAggregator.Enums;

public sealed class ProductStatus : SmartEnum<ProductStatus>
{
    public static readonly ProductStatus InStock = new(nameof(InStock), 1);
    public static readonly ProductStatus OutOfStock = new(nameof(OutOfStock), 2);
    public static readonly ProductStatus Discontinued = new(nameof(Discontinued), 3);

    private ProductStatus(string name, int id) : base(name, id)
    {
    }
}