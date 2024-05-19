using Ardalis.GuardClauses;
using Microsoft.Extensions.Logging;
using RookieShop.Application.Products.Commands.Update;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Enums;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Storage.Azurite;
using RookieShop.UnitTests.Builders;

namespace RookieShop.UnitTests.Application.ProductHandlerTest;

public sealed class UpdateProduct
{
    private readonly UpdateProductHandler _handler;
    private readonly Mock<IRepository<Product>> _repositoryMock;

    public UpdateProduct()
    {
        Mock<ILogger<UpdateProductHandler>> loggerMock = new();
        Mock<IAzuriteService> azuriteServiceMock = new();
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object, azuriteServiceMock.Object, loggerMock.Object);
    }

    private static Product CreateProductEntity() =>
        new("Product Name", "Product Description", 100, ProductPriceBuilder.TestPrice,
            ProductPriceBuilder.TestPriceSale, null, new(Guid.NewGuid()));

    [Fact]
    public async Task GivenValidRequest_ShouldUpdateProduct_IfProductExists()
    {
        // Arrange
        var command = new UpdateProductCommand(new(Guid.NewGuid()), "Product Name", "Product Description", 100,
            ProductPriceBuilder.TestPrice, ProductPriceBuilder.TestPriceSale, null, false, null, ProductStatus.InStock);
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<ProductId>(), CancellationToken.None))
            .ReturnsAsync(CreateProductEntity);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Value.Name.Should().Be("Product Name");
        result.Value.Description.Should().Be("Product Description");
        result.Value.Price.Should().Be(100);
        _repositoryMock.Verify(repo =>
            repo.UpdateAsync(It.IsAny<Product>(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GivenValidRequest_ShouldThrowNotFoundException_IfProductIsNotExists()
    {
        // Arrange
        var command = new UpdateProductCommand(new(Guid.NewGuid()), "Product Name", "Product Description", 100,
            ProductPriceBuilder.TestPrice, ProductPriceBuilder.TestPriceSale, null, false, null, ProductStatus.InStock);
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<ProductId>(), CancellationToken.None))
            .ReturnsAsync((Product?)null);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
        _repositoryMock.Verify(repo => repo.GetByIdAsync(It.IsAny<ProductId>(), CancellationToken.None), Times.Once);
        _repositoryMock.Verify(repo =>
            repo.UpdateAsync(It.IsAny<Product>(), CancellationToken.None), Times.Never);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task GivenNullOrEmptyName_ShouldThrowArgumentException(string? name)
    {
        // Arrange
        var command = new UpdateProductCommand(new(Guid.NewGuid()), name!, "Product Description", 100,
            ProductPriceBuilder.TestPrice, ProductPriceBuilder.TestPriceSale, null, false, null, ProductStatus.InStock);
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<ProductId>(), CancellationToken.None))
            .ReturnsAsync(CreateProductEntity);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>();
        _repositoryMock.Verify(repo => repo.GetByIdAsync(It.IsAny<ProductId>(), CancellationToken.None), Times.Once);
        _repositoryMock.Verify(repo =>
            repo.UpdateAsync(It.IsAny<Product>(), CancellationToken.None), Times.Never);
    }
}