using RookieShop.Domain.Entities.FeedbackAggregator;

namespace RookieShop.UnitTests.Domain.FeedbackTest;

public sealed class UpdateFeedback
{
    private const string TestContent = "Test content";
    private const int TestRating = 5;

    [Fact]
    public void GivenValidFeedback_ShouldUpdateFeedback()
    {
        // Arrange
        var feedback = new Feedback(TestContent, TestRating, new(Guid.NewGuid()), new(Guid.NewGuid()));
        const string newContent = "Updated content";
        const int newRating = 4;

        // Act
        feedback.Update(newContent, newRating, new(Guid.NewGuid()), new(Guid.NewGuid()));

        // Assert
        feedback.Content.Should().Be(newContent);
        feedback.Rating.Should().Be(newRating);
    }

    [Theory]
    [InlineData(6)]
    [InlineData(0)]
    public void GivenInvalidRating_ShouldThrowException(int rating)
    {
        // Arrange
        var feedback = new Feedback(TestContent, TestRating, new(Guid.NewGuid()), new(Guid.NewGuid()));

        // Act
        var act = () => feedback.Update(TestContent, rating, new(Guid.NewGuid()), new(Guid.NewGuid()));

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}