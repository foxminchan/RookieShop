using Ardalis.GuardClauses;
using RookieShop.Application.Feedbacks.Commands.Delete;
using RookieShop.Domain.Entities.FeedbackAggregator;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.UnitTests.Application.FeedbackHandlerTest;

public sealed class DeleteFeedback
{
    private readonly DeleteFeedbackHandler _handler;
    private readonly Mock<IRepository<Feedback>> _repositoryMock;

    public DeleteFeedback()
    {
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object);
    }

    private static Feedback CreateFeedbackEntity() =>
        new("Feedback Content", 3, new(Guid.NewGuid()), new(Guid.NewGuid()));

    [Fact]
    public async Task GivenValidId_ShouldReturnSuccessResult_IfFeedbackExists()
    {
        // Arrange
        var command = new DeleteFeedbackCommand(new(Guid.NewGuid()));
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<FeedbackId>(), CancellationToken.None))
            .ReturnsAsync(CreateFeedbackEntity);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        _repositoryMock.Verify(repo =>
            repo.DeleteAsync(It.IsAny<Feedback>(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GivenValidId_ShouldThrowNotFoundException_IfFeedbackIsNotExists()
    {
        // Arrange
        var command = new DeleteFeedbackCommand(new(Guid.NewGuid()));
        _repositoryMock.Setup(repo =>
                repo.GetByIdAsync(It.IsAny<FeedbackId>(), CancellationToken.None))
            .ReturnsAsync((Feedback?)null);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
        _repositoryMock.Verify(repo => repo.GetByIdAsync(It.IsAny<FeedbackId>(), CancellationToken.None), Times.Once);
        _repositoryMock.Verify(repo =>
            repo.DeleteAsync(It.IsAny<Feedback>(), CancellationToken.None), Times.Never);
    }
}