using Microsoft.Extensions.Logging;
using RookieShop.Application.Products.Commands.Create;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Ai.Embedded;
using RookieShop.Infrastructure.Storage.Azurite;
using RookieShop.UnitTests.Builders;

namespace RookieShop.UnitTests.Application.ProductHandlerTest;

public sealed class CreateProduct
{
    private readonly CreateProductHandler _handler;
    private readonly Mock<IRepository<Product>> _repositoryMock;

    public CreateProduct()
    {
        Mock<IAiService> aiServiceMock = new();
        Mock<ILogger<CreateProductHandler>> loggerMock = new();
        Mock<IAzuriteService> azuriteServiceMock = new();
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object, azuriteServiceMock.Object, aiServiceMock.Object, loggerMock.Object);
    }

    private static Product CreateProductEntity() =>
        new("Product Name", "Product Description", 100, ProductPriceBuilder.TestPrice,
            ProductPriceBuilder.TestPriceSale, null, new(Guid.NewGuid()));

    [Fact]
    public async Task GivenValidData_ShouldReturnSuccessResult()
    {
        // Arrange
        var command = new CreateProductCommand("Product Name", "Product Description", 100,
            ProductPriceBuilder.TestPrice,
            ProductPriceBuilder.TestPriceSale, null, new(Guid.NewGuid()));
        _repositoryMock.Setup(repo =>
                repo.AddAsync(It.IsAny<Product>(), CancellationToken.None))
            .ReturnsAsync(CreateProductEntity);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        _repositoryMock.Verify(repo =>
            repo.AddAsync(It.IsAny<Product>(), CancellationToken.None), Times.Once);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task GivenNullOrEmptyName_ShouldThrowArgumentException(string? name)
    {
        // Arrange
        var command = new CreateProductCommand(name!, "Product Description", 100,
            ProductPriceBuilder.TestPrice, ProductPriceBuilder.TestPriceSale, null, new(Guid.NewGuid()));

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>();
        _repositoryMock.Verify(repo =>
            repo.AddAsync(It.IsAny<Product>(), CancellationToken.None), Times.Never);
    }

    [Fact]
    public async Task GivenQuantityDesiredLessThanZero_ShouldThrowArgumentException()
    {
        // Arrange
        var command = new CreateProductCommand("Product Name", "Product Description", -9,
            ProductPriceBuilder.TestPrice, ProductPriceBuilder.TestPriceSale, null, new(Guid.NewGuid()));

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>();
        _repositoryMock.Verify(repo =>
            repo.AddAsync(It.IsAny<Product>(), CancellationToken.None), Times.Never);
    }
}