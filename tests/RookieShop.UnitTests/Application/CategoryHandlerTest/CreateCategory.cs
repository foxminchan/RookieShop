using Microsoft.Extensions.Logging;
using RookieShop.Application.Categories.Commands.Create;
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.UnitTests.Application.CategoryHandlerTest;

public class CreateCategory
{
    private readonly CreateCategoryHandler _handler;
    private readonly Mock<IRepository<Category>> _repositoryMock;

    public CreateCategory()
    {
        Mock<ILogger<CreateCategoryHandler>> loggerMock = new();
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object, loggerMock.Object);
    }

    private static Category CreateCategoryEntity() => new("Category Name", "Category Description");

    [Fact]
    public async Task GivenValidData_ShouldReturnSuccessResult()
    {
        // Arrange
        var command = new CreateCategoryCommand("Category Name", "Category Description");
        _repositoryMock.Setup(repo =>
                repo.AddAsync(It.IsAny<Category>(), CancellationToken.None))
            .ReturnsAsync(CreateCategoryEntity);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        _repositoryMock.Verify(repo =>
            repo.AddAsync(It.IsAny<Category>(), CancellationToken.None), Times.Once);
    }

    [Theory]
    [InlineData(null, "Category Description")]
    [InlineData(null, null)]
    public async Task GivenNullData_ShouldThrowArgumentNullException(string? name, string? description)
    {
        // Arrange
        var command = new CreateCategoryCommand(name!, description);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            await _handler.Handle(command, CancellationToken.None));
    }
}