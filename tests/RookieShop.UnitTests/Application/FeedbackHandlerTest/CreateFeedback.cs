using Microsoft.Extensions.Logging;
using RookieShop.Application.Feedbacks.Commands.Create;
using RookieShop.Domain.Entities.FeedbackAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.UnitTests.Application.FeedbackHandlerTest;

public sealed class CreateFeedback
{
    private readonly CreateFeedbackHandler _handler;
    private readonly Mock<IRepository<Feedback>> _repositoryMock;

    public CreateFeedback()
    {
        Mock<ILogger<CreateFeedbackHandler>> loggerMock = new();
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object, loggerMock.Object);
    }

    private static Feedback CreateFeedbackEntity() =>
        new("Feedback Content", 3, new(Guid.NewGuid()), new(Guid.NewGuid()));

    [Fact]
    public async Task GivenValidData_ShouldReturnSuccessResult()
    {
        // Arrange
        var command = new CreateFeedbackCommand(new(Guid.NewGuid()), 3, "Feedback Content", new(Guid.NewGuid()));
        _repositoryMock.Setup(repo =>
                repo.AddAsync(It.IsAny<Feedback>(), CancellationToken.None))
            .ReturnsAsync(CreateFeedbackEntity);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        _repositoryMock.Verify(repo =>
            repo.AddAsync(It.IsAny<Feedback>(), CancellationToken.None), Times.Once);
    }

    [Theory]
    [InlineData("", 0)]
    [InlineData(null, 0)]
    [InlineData("Feedback Content", -9)]
    public async Task GivenNullOrEmptyData_ShouldThrowArgumentException(string? content, int rating)
    {
        // Arrange
        var command = new CreateFeedbackCommand(new(Guid.NewGuid()), rating, content, new(Guid.NewGuid()));

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>();
        _repositoryMock.Verify(repo =>
            repo.AddAsync(It.IsAny<Feedback>(), CancellationToken.None), Times.Never);
    }
}