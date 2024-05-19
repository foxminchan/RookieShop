using FluentAssertions;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.OrderAggregator;
using RookieShop.Domain.Entities.OrderAggregator.Enums;
using RookieShop.UnitTests.Builders;

namespace RookieShop.UnitTests.Domain.OrderTest;

public sealed class CreateOrder
{
    [Fact]
    public void GivenValidOrder_ShouldCreateOrder()
    {
        // Arrange
        var customerId = new CustomerId(Guid.NewGuid());
        const OrderStatus orderStatus = OrderStatus.Pending;

        // Act
        var order = Order.Factory.Create(
            PaymentMethod.Card,
            CardBuilder.TestLast4Digits,
            CardBuilder.TestBrandName,
            CardBuilder.TestChargeId,
            ShippingAddressBuilder.TestStreet,
            ShippingAddressBuilder.TestCity,
            ShippingAddressBuilder.TestProvince,
            customerId,
            orderStatus,
            [
                new(new(Guid.NewGuid()), 1, 100),
                new(new(Guid.NewGuid()), 2, 200),
                new(new(Guid.NewGuid()), 3, 300)
            ]);

        // Assert
        Assert.NotNull(order);
        order.PaymentMethod.Should().Be(PaymentMethod.Card);
        order.Card!.Last4Digits.Should().Be(CardBuilder.TestLast4Digits);
    }

    [Fact]
    public void GivenDefaultCustomerId_ShouldThrowArgumentException()
    {
        // Arrange
        const OrderStatus orderStatus = OrderStatus.Pending;

        // Act
        Action act = () => Order.Factory.Create(
            PaymentMethod.Card,
            CardBuilder.TestLast4Digits,
            CardBuilder.TestBrandName,
            CardBuilder.TestChargeId,
            ShippingAddressBuilder.TestStreet,
            ShippingAddressBuilder.TestCity,
            ShippingAddressBuilder.TestProvince,
            default,
            orderStatus,
            [
                new(new(Guid.NewGuid()), 1, 100),
                new(new(Guid.NewGuid()), 2, 200),
                new(new(Guid.NewGuid()), 3, 300)
            ]);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void GivenNullOrderItems_ShouldThrowArgumentException()
    {
        // Arrange
        var customerId = new CustomerId(Guid.NewGuid());
        const OrderStatus orderStatus = OrderStatus.Pending;

        // Act
        Action act = () => Order.Factory.Create(
            PaymentMethod.Card,
            CardBuilder.TestLast4Digits,
            CardBuilder.TestBrandName,
            CardBuilder.TestChargeId,
            ShippingAddressBuilder.TestStreet,
            ShippingAddressBuilder.TestCity,
            ShippingAddressBuilder.TestProvince,
            customerId,
            orderStatus,
            []);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}