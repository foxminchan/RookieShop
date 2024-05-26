using RookieShop.Domain.Entities.BasketAggregator;

namespace RookieShop.UnitTests.Domain.BasketTest;

public sealed class CreateBasket
{
    [Fact]
    public void GivenValidData_ShouldCreateBasket()
    {
        // Arrange
        var accountId = Guid.NewGuid();

        // Act
        var basket = Basket.Factory.Create(accountId, new(Guid.NewGuid()), 1, 100);

        // Assert
        basket.Should().NotBeNull();
        basket.AccountId.Should().Be(accountId);
        basket.BasketDetails.Should().HaveCount(2);
        basket.TotalPrice().Should().Be(500);
    }
}