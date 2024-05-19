using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.UnitTests.Domain.BasketTest;

public sealed class CreateBasketItem
{
    [Fact]
    public void GivenValidData_ShouldCreateBasketItem()
    {
        // Arrange
        var productId = new ProductId(Guid.NewGuid());
        const int quantity = 1;
        const int price = 100;

        // Act
        var basketDetail = new BasketDetail(productId, quantity, price);

        // Assert
        basketDetail.Should().NotBeNull();
        basketDetail.Id.Should().Be(productId);
        basketDetail.Quantity.Should().Be(quantity);
        basketDetail.Price.Should().Be(price);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 100)]
    [InlineData(-1, -90)]
    [InlineData(10, -200)]
    public void GivenInvalidQuantityAndPrice_ShouldThrowArgumentOutOfRangeException(int quantity, decimal price)
    {
        // Act
        Func<BasketDetail> act = () => new(new(Guid.NewGuid()), quantity, price);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void GivenDefaultProductId_ShouldThrowArgumentException()
    {
        // Act
        Func<BasketDetail> act = () => new(default, 1, 100);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}