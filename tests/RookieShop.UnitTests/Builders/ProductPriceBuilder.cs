using RookieShop.Domain.Entities.ProductAggregator.ValueObjects;

namespace RookieShop.UnitTests.Builders;

public sealed class ProductPriceBuilder
{
    private ProductPrice _productPrice;

    public ProductPriceBuilder() => _productPrice = WithDefaultValues();

    public static decimal TestPrice => 100;
    public static decimal TestPriceSale => 90;

    public ProductPrice Build() => _productPrice;

    public ProductPrice WithDefaultValues()
    {
        _productPrice = ProductPrice.Create(TestPrice, TestPriceSale);
        return _productPrice;
    }
}