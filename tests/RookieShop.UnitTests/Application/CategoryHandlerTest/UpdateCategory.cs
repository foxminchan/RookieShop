using Ardalis.GuardClauses;
using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using RookieShop.Application.Categories.Commands.Update;
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.UnitTests.Application.CategoryHandlerTest;

public sealed class UpdateCategory
{
    private readonly UpdateCategoryHandler _handler;
    private readonly Mock<IRepository<Category>> _repositoryMock;

    public UpdateCategory()
    {
        Mock<ILogger<UpdateCategoryHandler>> loggerMock = new();
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object, loggerMock.Object);
    }

    private static Category CreateCategoryEntity() => new("Category Name", "Category Description");

    [Fact]
    public async Task GivenValidRequest_ShouldUpdateCategory_IfCategoryExists()
    {
        // Arrange
        var command = new UpdateCategoryCommand(new(Guid.NewGuid()), "Category Name", "Category Description");
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<CategoryId>(), CancellationToken.None))
            .ReturnsAsync(CreateCategoryEntity);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Status.Should().Be(ResultStatus.Ok);
    }

    [Fact]
    public async Task GivenValidRequest_ShouldThrowNotFoundException_IfCategoryIsNotExists()
    {
        // Arrange
        var command = new UpdateCategoryCommand(new(Guid.NewGuid()), "Category Name", "Category Description");
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<CategoryId>(), CancellationToken.None))
            .ReturnsAsync((Category?)null);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task GivenCategoryNameIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var command = new UpdateCategoryCommand(new(Guid.NewGuid()), null!, "Category Description");
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<CategoryId>(), CancellationToken.None))
            .ReturnsAsync(CreateCategoryEntity);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArgumentNullException>();
    }
}