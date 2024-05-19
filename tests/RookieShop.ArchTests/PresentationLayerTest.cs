using RookieShop.ApiService;

namespace RookieShop.ArchTests;

public sealed class PresentationLayerTest
{
    [Fact]
    public void Presentation_Should_HaveDependencyOnApplication()
    {
        // Arrange
        var presentationAssembly = AssemblyReference.Assembly;

        // Act
        var result = Types.InAssembly(presentationAssembly)
            .That()
            .ResideInNamespace(nameof(ApiService))
            .Should()
            .HaveDependencyOn(nameof(Application))
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Presentation_Should_HaveNotDependencyOnDomain()
    {
        // Arrange
        var presentationAssembly = AssemblyReference.Assembly;

        // Act
        var result = Types.InAssembly(presentationAssembly)
            .That()
            .ResideInNamespace(nameof(ApiService))
            .ShouldNot()
            .HaveDependencyOn(nameof(Domain))
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Presentation_Should_HaveNotDependencyOnInfrastructure()
    {
        // Arrange
        var presentationAssembly = AssemblyReference.Assembly;

        // Act
        var result = Types.InAssembly(presentationAssembly)
            .That()
            .ResideInNamespace(nameof(ApiService))
            .ShouldNot()
            .HaveDependencyOn(nameof(Infrastructure))
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Presentation_Should_HaveNotDependencyOnPersistence()
    {
        // Arrange
        var presentationAssembly = AssemblyReference.Assembly;

        // Act
        var result = Types.InAssembly(presentationAssembly)
            .That()
            .ResideInNamespace(nameof(ApiService))
            .ShouldNot()
            .HaveDependencyOn(nameof(Persistence))
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
}