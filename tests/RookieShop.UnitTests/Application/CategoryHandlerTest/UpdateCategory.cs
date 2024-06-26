﻿using Ardalis.GuardClauses;
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
        Mock<IPublisher> publisherMock = new();
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object, loggerMock.Object, publisherMock.Object);
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
        result.Value.Name.Should().Be("Category Name");
        result.Value.Description.Should().Be("Category Description");
        _repositoryMock.Verify(repo =>
            repo.UpdateAsync(It.IsAny<Category>(), CancellationToken.None), Times.Once);
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
        _repositoryMock.Verify(repo => repo.GetByIdAsync(It.IsAny<CategoryId>(), CancellationToken.None), Times.Once);
        _repositoryMock.Verify(repo =>
            repo.UpdateAsync(It.IsAny<Category>(), CancellationToken.None), Times.Never);
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
        _repositoryMock.Verify(repo =>
            repo.UpdateAsync(It.IsAny<Category>(), CancellationToken.None), Times.Never);
    }
}