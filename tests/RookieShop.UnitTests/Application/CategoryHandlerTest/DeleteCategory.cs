using Ardalis.GuardClauses;
using RookieShop.Application.Categories.Commands.Delete;
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.UnitTests.Application.CategoryHandlerTest;

public sealed class DeleteCategory
{
    private readonly DeleteCategoryHandler _handler;
    private readonly Mock<IRepository<Category>> _repositoryMock;

    public DeleteCategory()
    {
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object);
    }

    private static Category CreateCategoryEntity() => new("Category Name", "Category Description");

    [Fact]
    public async Task GivenValidId_ShouldReturnSuccessResult_IfCategoryExists()
    {
        // Arrange
        var command = new DeleteCategoryCommand(new(Guid.NewGuid()));
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<CategoryId>(), CancellationToken.None))
            .ReturnsAsync(CreateCategoryEntity);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        _repositoryMock.Verify(repo =>
            repo.DeleteAsync(It.IsAny<Category>(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GivenValidId_ShouldThrowNotFoundException_IfCategoryIsNotExists()
    {
        // Arrange
        var command = new DeleteCategoryCommand(new(Guid.NewGuid()));
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<CategoryId>(), CancellationToken.None))
            .ReturnsAsync((Category?)null);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}