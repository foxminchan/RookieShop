using Ardalis.GuardClauses;
using RookieShop.Application.Products.DTOs;
using RookieShop.Application.Products.Queries.Get;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Specifications;
using RookieShop.Domain.SharedKernel;
using RookieShop.UnitTests.Builders;

namespace RookieShop.UnitTests.Application.ProductHandlerTest;

public sealed class GetProduct
{
    private readonly GetProductHandler _handler;
    private readonly Mock<IReadRepository<Product>> _repositoryMock;

    public GetProduct()
    {
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object);
    }

    [Fact]
    public async Task GivenValidId_ShouldReturnProduct_IfProductExists()
    {
        // Arrange
        var product = new Product("Product Name", "Product Description", 100, ProductPriceBuilder.TestPrice,
            ProductPriceBuilder.TestPriceSale, null, new(Guid.NewGuid()));
        _repositoryMock.Setup(repo =>
                repo.FirstOrDefaultAsync(It.IsAny<ProductByIdSpec>(), CancellationToken.None))
            .ReturnsAsync(product);

        var query = new GetProductQuery(new(Guid.NewGuid()));

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        _repositoryMock.Verify(repo =>
            repo.FirstOrDefaultAsync(It.IsAny<ProductByIdSpec>(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GivenValidId_ShouldThrowNotFoundException_IfProductNotExists()
    {
        // Arrange
        var query = new GetProductQuery(new(Guid.NewGuid()));
        _repositoryMock.Setup(repo =>
                repo.FirstOrDefaultAsync(It.IsAny<ProductByIdSpec>(), CancellationToken.None))
            .ReturnsAsync((Product?)null);

        // Act
        Func<Task> act = async () => await _handler.Handle(query, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
        _repositoryMock.Verify(repo =>
            repo.FirstOrDefaultAsync(It.IsAny<ProductByIdSpec>(), CancellationToken.None), Times.Once);
    }
}