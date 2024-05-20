using Ardalis.GuardClauses;
using Microsoft.Extensions.Logging;
using RookieShop.Application.Baskets.Command.Update;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Infrastructure.Cache.Redis;

namespace RookieShop.UnitTests.Application.BasketHandlerTest;

public sealed class UpdateBasket
{
    private readonly UpdateBasketHandler _handler;
    private readonly Mock<IRedisService> _redisMock;

    public UpdateBasket()
    {
        Mock<ILogger<UpdateBasketHandler>> loggerMock = new();
        _redisMock = new();
        _handler = new(_redisMock.Object, loggerMock.Object);
    }

    private static readonly string _cacheKey = Guid.NewGuid().ToString();

    [Fact]
    public async Task GivenValidData_ShouldReturnNotFound_IfBasketIsNotExists()
    {
        // Arrange
        var command = new UpdateBasketCommand(
            new(_cacheKey),
            [
                new(new(Guid.NewGuid()), 9, 1000),
                new(new(Guid.NewGuid()), 5, 500),
                new(new(Guid.NewGuid()), 6, 200)
            ]);
        _redisMock.Setup(repo => repo.HashGetOrSetAsync<Basket>(nameof(Basket), _cacheKey, () => null!))!
            .ReturnsAsync((Basket?)null);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
        _redisMock.Verify(repo =>
                repo.HashGetOrSetAsync(nameof(Basket), It.IsAny<string>(), It.IsAny<Func<Basket>>()),
            Times.Once);
    }
}