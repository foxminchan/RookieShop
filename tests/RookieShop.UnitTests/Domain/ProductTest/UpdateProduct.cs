using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Enums;

namespace RookieShop.UnitTests.Domain.ProductTest;

public sealed class UpdateProduct
{
    private const string TestName = "Name 1";
    private const string TestDescription = "Description 1";
    private const int TestQuantity = 10;
    private const decimal TestPrice = 100m;
    private const decimal TestPriceSale = 90m;
    private static readonly string _testImageName = Guid.NewGuid().ToString();
    private readonly CategoryId _testCategoryId = new(Guid.NewGuid());

    [Fact]
    public void GivenValidData_ShouldCreateProduct()
    {
        // Arrange
        var product = new Product(TestName, TestDescription, TestQuantity, TestPrice, TestPriceSale, _testImageName,
            _testCategoryId);
        const string newName = "Name 2";
        const string newDescription = "Description 2";
        const int newQuantity = 20;
        const decimal newPrice = 200m;
        const decimal newPriceSale = 180m;
        var newImageName = Guid.NewGuid().ToString();
        var newCategoryId = new CategoryId(Guid.NewGuid());

        // Act
        product.Update(newName, newDescription, newQuantity, newPrice, newPriceSale, newImageName, newCategoryId,
            ProductStatus.InStock);

        // Assert
        product.Name.Should().Be(newName);
        product.Description.Should().Be(newDescription);
        product.Quantity.Should().Be(newQuantity);
        product.Status.Should().Be(ProductStatus.InStock);
        product.Price.Price.Should().Be(newPrice);
        product.Price.PriceSale.Should().Be(newPriceSale);
        product.ImageName.Should().Be(newImageName);
        product.CategoryId.Should().Be(newCategoryId);
    }

    [Fact]
    public void GivenNameIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var product = new Product(TestName, TestDescription, TestQuantity, TestPrice, TestPriceSale, _testImageName,
            _testCategoryId);

        // Act
        var act = () => product.Update(null!, TestDescription, TestQuantity, TestPrice, TestPriceSale, _testImageName,
            _testCategoryId, ProductStatus.InStock);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData(-9)]
    [InlineData(unchecked(int.MaxValue + 1))]
    public void GivenQuantityDesiredLessThanZero_OrGreaterThanMaxValue_ShouldThrowArgumentOutOfRangeException(
        int quantity)
    {
        // Arrange
        var product = new Product(TestName, TestDescription, TestQuantity, TestPrice, TestPriceSale, _testImageName,
            _testCategoryId);

        // Act
        var act = () => product.Update(TestName, TestDescription, quantity, TestPrice, TestPriceSale, _testImageName,
            _testCategoryId, ProductStatus.InStock);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}