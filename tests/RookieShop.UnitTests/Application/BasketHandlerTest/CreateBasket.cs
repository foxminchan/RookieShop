using Microsoft.Extensions.Logging;
using RookieShop.Application.Baskets.Command.Create;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Infrastructure.Cache.Redis;

namespace RookieShop.UnitTests.Application.BasketHandlerTest;

public sealed class CreateBasket
{
    private readonly CreateBasketHandler _handler;
    private readonly Mock<IRedisService> _redisMock;

    public CreateBasket()
    {
        Mock<ILogger<CreateBasketHandler>> loggerMock = new();
        _redisMock = new();
        _handler = new(_redisMock.Object, loggerMock.Object);
    }

    private static Basket CreateBasketEntity() => Basket.Factory.Create(Guid.NewGuid(), [
        new(new(Guid.NewGuid()), 3, 1000),
        new(new(Guid.NewGuid()), 2, 500),
        new(new(Guid.NewGuid()), 1, 200)
    ]);

    [Fact]
    public async Task GivenValidData_ShouldReturnSuccessResult()
    {
        // Arrange
        var command = new CreateBasketCommand(
            Guid.NewGuid(),
            [
                new(new(Guid.NewGuid()), 3, 1000),
                new(new(Guid.NewGuid()), 2, 500),
                new(new(Guid.NewGuid()), 1, 200)
            ]);
        _redisMock.Setup(repo =>
                repo.HashGetOrSetAsync(nameof(Basket), It.IsAny<string>(), It.IsAny<Func<Basket>>()))
            .ReturnsAsync(CreateBasketEntity);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        _redisMock.Verify(repo =>
                repo.HashGetOrSetAsync(nameof(Basket), It.IsAny<string>(), It.IsAny<Func<Basket>>()),
            Times.Once);
    }

    [Fact]
    public async Task GivenNullBasketItems_ShouldThrowArgumentNullException()
    {
        // Arrange
        var command = new CreateBasketCommand(Guid.NewGuid(), null!);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArgumentNullException>();
        _redisMock.Verify(repo =>
                repo.HashGetOrSetAsync(nameof(Basket), It.IsAny<string>(), It.IsAny<Func<Basket>>()),
            Times.Never);
    }
}