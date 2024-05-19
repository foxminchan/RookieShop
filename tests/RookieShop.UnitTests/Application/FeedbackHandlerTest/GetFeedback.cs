using Ardalis.GuardClauses;
using RookieShop.Application.Feedbacks.Queries.Get;
using RookieShop.Domain.Entities.FeedbackAggregator;
using RookieShop.Domain.Entities.FeedbackAggregator.Specifications;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.UnitTests.Application.FeedbackHandlerTest;

public sealed class GetFeedback
{
    private readonly GetFeedbackHandler _handler;
    private readonly Mock<IReadRepository<Feedback>> _repositoryMock;

    public GetFeedback()
    {
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object);
    }

    private static Feedback CreateFeedbackEntity() =>
        new("Feedback Content", 3, new(Guid.NewGuid()), new(Guid.NewGuid()));

    [Fact]
    public async Task GivenValidId_ShouldReturnFeedback_IfFeedbackExists()
    {
        // Arrange
        var query = new GetFeedbackQuery(new(Guid.NewGuid()));
        _repositoryMock.Setup(repo =>
                repo.FirstOrDefaultAsync(It.IsAny<FeedbackByIdSpec>(), CancellationToken.None))
            .ReturnsAsync(CreateFeedbackEntity);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Content.Should().Be("Feedback Content");
        result.Value.Rating.Should().Be(3);
        _repositoryMock.Verify(repo => repo.FirstOrDefaultAsync(It.IsAny<FeedbackByIdSpec>(), CancellationToken.None),
            Times.Once);
    }

    [Fact]
    public async Task GivenValidId_ShouldReturnNull_IfFeedbackIsNotExists()
    {
        // Arrange
        var query = new GetFeedbackQuery(new(Guid.NewGuid()));
        _repositoryMock.Setup(repo =>
                repo.FirstOrDefaultAsync(It.IsAny<FeedbackByIdSpec>(), CancellationToken.None))
            .ReturnsAsync((Feedback?)null);

        // Act
        Func<Task> act = async () => await _handler.Handle(query, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
        _repositoryMock.Verify(repo => repo.FirstOrDefaultAsync(It.IsAny<FeedbackByIdSpec>(), CancellationToken.None),
            Times.Once);
    }
}