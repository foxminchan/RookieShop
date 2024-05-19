using FluentAssertions;
using RookieShop.Domain.Entities.BasketAggregator;

namespace RookieShop.UnitTests.Domain.BasketTest;

public sealed class CreateBasket
{
    [Fact]
    public void GivenValidData_ShouldCreateBasket()
    {
        // Arrange
        var accountId = Guid.NewGuid();
        List<BasketDetail> basketDetails =
        [
            new(new(Guid.NewGuid()), 1, 100),
            new(new(Guid.NewGuid()), 2, 200)
        ];

        // Act
        var basket = Basket.Factory.Create(accountId, basketDetails);

        // Assert
        Assert.NotNull(basket);
        Assert.Equal(accountId, basket.AccountId);
        Assert.Equal(2, basket.BasketDetails.Count);
        Assert.Equal(500, basket.TotalPrice());
    }

    [Fact]
    public void GivenEmptyBasketDetails_ShouldCreateBasket()
    {
        // Arrange
        var accountId = Guid.NewGuid();

        // Act
        Action act = () => Basket.Factory.Create(accountId, []);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}