using RookieShop.Domain.Entities.OrderAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.UnitTests.Domain.OrderTest;

public sealed class CreateOrderItem
{
    [Fact]
    public void GivenValidData_ShouldCreateOrderItem()
    {
        // Arrange
        var productId = new ProductId(Guid.NewGuid());
        const int quantity = 1;
        const int price = 100;

        // Act
        var orderDetail = new OrderDetail(productId, quantity, price);

        // Assert
        Assert.NotNull(orderDetail);
        Assert.Equal(productId, orderDetail.ProductId);
        Assert.Equal(quantity, orderDetail.Quantity);
        Assert.Equal(price, orderDetail.Price);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 100)]
    [InlineData(-1, -90)]
    [InlineData(10, -200)]
    public void GivenInvalidQuantityAndPrice_ShouldThrowArgumentOutOfRangeException(int quantity, decimal price)
    {
        // Act
        Assert.Throws<ArgumentOutOfRangeException>(() => new OrderDetail(new(Guid.NewGuid()), quantity, price));
    }

    [Fact]
    public void GivenDefaultProductId_ShouldThrowArgumentNullException()
    {
        // Act
        Assert.Throws<ArgumentException>(() => new OrderDetail(default, 1, 100));
    }
}