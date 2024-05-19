using RookieShop.Domain.Entities.CategoryAggregator;

namespace RookieShop.UnitTests.Domain.CategoryTest;

public sealed class UpdateCategory
{
    private const string TestName = "Category 1";
    private const string TestDescription = "Description 1";

    [Fact]
    public void GivenNewNameAndDescription_ShouldUpdateCategory()
    {
        // Arrange
        var category = new Category(TestName, TestDescription);
        const string newName = "Category 2";
        const string newDescription = "Description 2";

        // Act
        category.Update(newName, newDescription);

        // Assert
        category.Name.Should().Be(newName);
        category.Description.Should().Be(newDescription);
    }

    [Fact]
    public void GivenNewName_ShouldUpdateCategory()
    {
        // Arrange
        var category = new Category(TestName, TestDescription);
        const string newName = "Category 2";

        // Act
        category.Update(newName, null);

        // Assert
        category.Name.Should().NotBe(TestName);
        category.Description.Should().BeNull();
    }

    [Fact]
    public void GivenNewDescription_ShouldThrowArgumentNullException()
    {
        // Arrange
        var category = new Category(TestName, TestDescription);
        const string newDescription = "Description 2";

        // Act
        var act = () => category.Update(null!, newDescription);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }
}