using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Enums;
using RookieShop.UnitTests.Builders;

namespace RookieShop.UnitTests.Domain.ProductTest;

public sealed class RemoveStock
{
    private const string TestName = "Name 1";
    private const string TestDescription = "Description 1";
    private const int TestQuantity = 10;
    private static readonly string _testImageName = Guid.NewGuid().ToString();
    private readonly CategoryId _testCategoryId = new(Guid.NewGuid());

    [Fact]
    public void GivenValidQuantityDesired_ShouldRemoveStock()
    {
        // Arrange
        var product = new Product(TestName, TestDescription, TestQuantity, ProductPriceBuilder.TestPrice,
            ProductPriceBuilder.TestPriceSale, _testImageName,
            _testCategoryId);
        const int quantityDesired = 5;
        const int expectedQuantity = 5;
        const ProductStatus expectedStatus = ProductStatus.InStock;

        // Act
        product.RemoveStock(quantityDesired);

        // Assert
        product.Quantity.Should().Be(expectedQuantity);
        product.Status.Should().Be(expectedStatus);
    }

    [Theory]
    [InlineData(-9)]
    [InlineData(unchecked(int.MaxValue + 1))]
    public void GivenQuantityDesiredLessThanZero_OrGreaterThanMaxValue_ShouldThrowArgumentOutOfRangeException(int quantityDesired)
    {
        // Arrange
        var product = new Product(TestName, TestDescription, TestQuantity, ProductPriceBuilder.TestPrice,
            ProductPriceBuilder.TestPriceSale, _testImageName,
            _testCategoryId);

        // Act
        var act = () => product.RemoveStock(quantityDesired);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}