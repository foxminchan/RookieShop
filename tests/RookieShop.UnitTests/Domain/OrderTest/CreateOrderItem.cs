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
        orderDetail.Should().NotBeNull();
        orderDetail.ProductId.Should().Be(productId);
        orderDetail.Quantity.Should().Be(quantity);
        orderDetail.Price.Should().Be(price);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 100)]
    [InlineData(-1, -90)]
    [InlineData(10, -200)]
    public void GivenInvalidQuantityAndPrice_ShouldThrowArgumentOutOfRangeException(int quantity, decimal price)
    {
        // Act
        Func<OrderDetail> act = () => new(new(Guid.NewGuid()), quantity, price);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void GivenDefaultProductId_ShouldThrowArgumentNullException()
    {
        // Act
        Func<OrderDetail> act = () => new(default, 1, 100);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}