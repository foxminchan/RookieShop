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
        Assert.NotNull(basketDetail);
        Assert.Equal(productId, basketDetail.Id);
        Assert.Equal(quantity, basketDetail.Quantity);
        Assert.Equal(price, basketDetail.Price);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 100)]
    [InlineData(-1, -90)]
    [InlineData(10, -200)]
    public void GivenInvalidQuantityAndPrice_ShouldThrowArgumentOutOfRangeException(int quantity, decimal price)
    {
        // Act
        Assert.Throws<ArgumentOutOfRangeException>(() => new BasketDetail(new(Guid.NewGuid()), quantity, price));
    }

    [Fact]
    public void GivenDefaultProductId_ShouldThrowArgumentNullException()
    {
        // Act
        Assert.Throws<ArgumentException>(() => new BasketDetail(default, 1, 100));
    }
}