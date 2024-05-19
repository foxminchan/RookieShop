using Ardalis.GuardClauses;
using Microsoft.Extensions.Logging;
using RookieShop.Application.Feedbacks.Command.Update;
using RookieShop.Domain.Entities.FeedbackAggregator;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.UnitTests.Application.FeedbackHandlerTest;

public sealed class UpdateFeedback
{
    private readonly UpdateFeedbackHandler _handler;
    private readonly Mock<IRepository<Feedback>> _repositoryMock;

    public UpdateFeedback()
    {
        Mock<ILogger<UpdateFeedbackHandler>> loggerMock = new();
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object, loggerMock.Object);
    }

    private static Feedback CreateFeedbackEntity() =>
        new("Feedback Content", 3, new(Guid.NewGuid()), new(Guid.NewGuid()));

    [Fact]
    public async Task GivenValidRequest_ShouldUpdateFeedback_IfFeedbackExists()
    {
        // Arrange
        var command = new UpdateFeedbackCommand(new(Guid.NewGuid()), new(Guid.NewGuid()), 2, "Feedback Content",
            new(Guid.NewGuid()));
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<FeedbackId>(), CancellationToken.None))
            .ReturnsAsync(CreateFeedbackEntity);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Value.Content.Should().Be("Feedback Content");
        _repositoryMock.Verify(repo =>
            repo.UpdateAsync(It.IsAny<Feedback>(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GivenValidRequest_ShouldThrowNotFoundException_IfFeedbackIsNotExists()
    {
        // Arrange
        var command = new UpdateFeedbackCommand(new(Guid.NewGuid()), new(Guid.NewGuid()), 2, "Feedback Content",
            new(Guid.NewGuid()));
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<FeedbackId>(), CancellationToken.None))
            .ReturnsAsync((Feedback?)null);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
        _repositoryMock.Verify(repo => repo.GetByIdAsync(It.IsAny<FeedbackId>(), CancellationToken.None), Times.Once);
        _repositoryMock.Verify(repo =>
            repo.UpdateAsync(It.IsAny<Feedback>(), CancellationToken.None), Times.Never);
    }

    [Theory]
    [InlineData("", 0)]
    [InlineData(null, 0)]
    [InlineData("Feedback Content", -9)]
    public async Task GivenNullOrEmptyData_ShouldThrowArgumentException(string? content, int rating)
    {
        // Arrange
        var command = new UpdateFeedbackCommand(new(Guid.NewGuid()), new(Guid.NewGuid()), rating, content,
            new(Guid.NewGuid()));
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<FeedbackId>(), CancellationToken.None))
            .ReturnsAsync(CreateFeedbackEntity);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>();
        _repositoryMock.Verify(repo => repo.GetByIdAsync(It.IsAny<FeedbackId>(), CancellationToken.None), Times.Once);
        _repositoryMock.Verify(repo =>
            repo.UpdateAsync(It.IsAny<Feedback>(), CancellationToken.None), Times.Never);
    }
}