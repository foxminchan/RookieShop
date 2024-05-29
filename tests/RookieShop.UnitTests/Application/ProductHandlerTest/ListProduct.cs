using RookieShop.Application.Products.Queries.List;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Specifications;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Storage.Azurite;
using RookieShop.UnitTests.Builders;

namespace RookieShop.UnitTests.Application.ProductHandlerTest;

public sealed class ListProduct
{
    private readonly ListProductsHandler _handler;
    private readonly Mock<IReadRepository<Product>> _repositoryMock;

    public ListProduct()
    {
        Mock<IAzuriteService> azuriteServiceMock = new();
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object, azuriteServiceMock.Object);
    }

    [Fact]
    public async Task GivenValidRequest_ShouldReturnNotEmptyList_IfProductsExist()
    {
        // Arrange
        List<Product> products =
        [
            new("Product Name1", "Product Description1", 100, ProductPriceBuilder.TestPrice,
                ProductPriceBuilder.TestPriceSale, null, null),
            new("Product Name2", "Product Description2", 100, ProductPriceBuilder.TestPrice,
                ProductPriceBuilder.TestPriceSale, null, null),
            new("Product Name3", "Product Description3", 100, ProductPriceBuilder.TestPrice,
                ProductPriceBuilder.TestPriceSale, null, null)
        ];
        _repositoryMock.Setup(repo =>
                repo.ListAsync(It.IsAny<ProductsFilterSpec>(), CancellationToken.None))
            .ReturnsAsync(products);

        var query = new ListProductsQuery(1, 0, null, false, null, []);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Value.Should().NotBeEmpty().And.HaveCount(3);
        _repositoryMock.Verify(repo =>
            repo.ListAsync(It.IsAny<ProductsFilterSpec>(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GivenValidRequest_ShouldReturnEmptyList_IfProductsNotExist()
    {
        // Arrange
        var query = new ListProductsQuery(1, 0, null, false, null, []);
        _repositoryMock.Setup(repo =>
                repo.ListAsync(It.IsAny<ProductsFilterSpec>(), CancellationToken.None))
            .ReturnsAsync([]);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Value.Should().BeEmpty();
        _repositoryMock.Verify(repo =>
            repo.ListAsync(It.IsAny<ProductsFilterSpec>(), CancellationToken.None), Times.Once);
    }
}