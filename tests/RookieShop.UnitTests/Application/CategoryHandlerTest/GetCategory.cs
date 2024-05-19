﻿using RookieShop.Application.Categories.Queries.Get;
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Domain.Entities.CategoryAggregator.Specifications;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.UnitTests.Application.CategoryHandlerTest;

public sealed class GetCategory
{
    private readonly GetCategoryHandler _handler;
    private readonly Mock<IReadRepository<Category>> _repositoryMock;

    public GetCategory()
    {
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object);
    }

    [Fact]
    public async Task GivenValidId_ShouldBeReturnNotBeNull_IfCategoryExists()
    {
        // Arrange
        var category = new Category("Category Name", "Category Description");
        _repositoryMock.Setup(repo =>
                repo.FirstOrDefaultAsync(It.IsAny<CategoryByIdSpec>(), CancellationToken.None))
            .ReturnsAsync(category);

        var query = new GetCategoryQuery(new(Guid.NewGuid()));

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
    }
}