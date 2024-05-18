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
        Assert.Equal(newName, category.Name);
        Assert.Equal(newDescription, category.Description);
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
        Assert.Equal(newName, category.Name);
        Assert.Null(category.Description);
    }

    [Fact]
    public void GivenNewDescription_ShouldThrowArgumentNullException()
    {
        // Arrange
        var category = new Category(TestName, TestDescription);
        const string newDescription = "Description 2";

        // Assert
        Assert.Throws<ArgumentNullException>(() => category.Update(null!, newDescription));
    }
}