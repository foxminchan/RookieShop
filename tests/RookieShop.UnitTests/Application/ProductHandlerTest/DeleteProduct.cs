using Ardalis.GuardClauses;
using RookieShop.Application.Products.Commands.Delete;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SharedKernel;
using RookieShop.UnitTests.Builders;

namespace RookieShop.UnitTests.Application.ProductHandlerTest;

public sealed class DeleteProduct
{
    private readonly DeleteProductHandler _handler;
    private readonly Mock<IRepository<Product>> _repositoryMock;

    public DeleteProduct()
    {
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object);
    }

    private static Product CreateProductEntity() =>
        new("Product Name", "Product Description", 100, ProductPriceBuilder.TestPrice,
            ProductPriceBuilder.TestPriceSale, null, new(Guid.NewGuid()));

    [Fact]
    public async Task GivenValidId_ShouldReturnSuccessResult_IfProductExists()
    {
        // Arrange
        var command = new DeleteProductCommand(new(Guid.NewGuid()));
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<ProductId>(), CancellationToken.None))
            .ReturnsAsync(CreateProductEntity);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        _repositoryMock.Verify(repo =>
            repo.UpdateAsync(It.IsAny<Product>(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GivenValidId_ShouldThrowNotFoundException_IfProductIsNotExists()
    {
        // Arrange
        var command = new DeleteProductCommand(new(Guid.NewGuid()));
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
}