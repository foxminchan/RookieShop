using RookieShop.Application.Feedbacks.Queries.List;
using RookieShop.Domain.Entities.FeedbackAggregator;
using RookieShop.Domain.Entities.FeedbackAggregator.Specifications;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.UnitTests.Application.FeedbackHandlerTest;

public sealed class ListFeedback
{
    private readonly ListFeedbackHandler _handler;
    private readonly Mock<IReadRepository<Feedback>> _repositoryMock;

    public ListFeedback()
    {
        _repositoryMock = new();
        _handler = new(_repositoryMock.Object);
    }


    [Fact]
    public async Task GivenValidRequest_ShouldReturnFeedbackList()
    {
        // Arrange
        List<Feedback> feedbackList =
        [
            new("Feedback Content 1", 1, new(Guid.NewGuid()), new(Guid.NewGuid())),
            new("Feedback Content 2", 2, new(Guid.NewGuid()), new(Guid.NewGuid())),
            new("Feedback Content 3", 3, new(Guid.NewGuid()), new(Guid.NewGuid()))
        ];
        _repositoryMock.Setup(repo => repo.ListAsync(
            It.IsAny<FeedbackFilterSpec>(), CancellationToken.None)).ReturnsAsync(feedbackList);

        var query = new ListFeedbackQuery(1, 0, null, false, null, null);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Value.Should().NotBeEmpty().And.HaveCount(3);
        _repositoryMock.Verify(repo =>
            repo.ListAsync(It.IsAny<FeedbackFilterSpec>(), CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task GivenValidRequest_ShouldReturnEmptyList_IfFeedbackNotExist()
    {
        // Arrange
        var query = new ListFeedbackQuery(1, 0, null, false, null, null);
        _repositoryMock.Setup(repo =>
                repo.ListAsync(It.IsAny<FeedbackFilterSpec>(), CancellationToken.None))
            .ReturnsAsync([]);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Value.Should().BeEmpty();
        _repositoryMock.Verify(repo =>
            repo.ListAsync(It.IsAny<FeedbackFilterSpec>(), CancellationToken.None), Times.Once);
    }
}