using RookieShop.Application.Categories.Queries.List;
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Domain.Entities.CategoryAggregator.Specifications;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.UnitTests.Application.CategoryHandlerTest;

public sealed class ListCategory
{
    private readonly ListCategoriesHandler _handler;
    private readonly Mock<IReadRepository<Category>> _repositoryMock;

    public ListCategory()
    {
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object);
    }

    [Fact]
    public async Task GivenValidRequest_ShouldReturnNotEmptyList_IfCategoriesExist()
    {
        // Arrange
        List<Category> categories =
        [
            new("Category Name 1", "Category Description 1"),
            new("Category Name 2", "Category Description 2"),
            new("Category Name 3", "Category Description 3")
        ];
        _repositoryMock.Setup(repo =>
                repo.ListAsync(It.IsAny<CategoriesFilterSpec>(), CancellationToken.None))
            .ReturnsAsync(categories);

        var query = new ListCategoriesQuery(1, 0);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Value.Should().NotBeEmpty().And.HaveCount(3);
    }

    [Fact]
    public async Task GivenValidRequest_ShouldReturnEmptyList_IfCategoriesNotExist()
    {
        // Arrange
        var query = new ListCategoriesQuery(1, 0);
        _repositoryMock.Setup(repo =>
                repo.ListAsync(It.IsAny<CategoriesFilterSpec>(), CancellationToken.None))
            .ReturnsAsync([]);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Value.Should().BeEmpty();
    }
}