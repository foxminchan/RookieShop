using RookieShop.Application;

namespace RookieShop.ArchTests;

public sealed class ApplicationLayerTest
{
    [Fact]
    public void Application_Should_HaveDependencyOnDomain()
    {
        // Arrange
        var applicationAssembly = AssemblyReference.Assembly;

        // Act
        var result = Types.InAssembly(applicationAssembly)
            .That()
            .ResideInNamespace(nameof(Application))
            .Should()
            .HaveDependencyOn(nameof(Domain))
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Application_Should_HaveDependencyOnInfrastructure()
    {
        // Arrange
        var applicationAssembly = AssemblyReference.Assembly;

        // Act
        var result = Types.InAssembly(applicationAssembly)
            .That()
            .ResideInNamespace(nameof(Application))
            .Should()
            .HaveDependencyOn(nameof(Infrastructure))
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Application_Should_HaveNotDependencyOnPersistence()
    {
        // Arrange
        var applicationAssembly = AssemblyReference.Assembly;

        // Act
        var result = Types.InAssembly(applicationAssembly)
            .That()
            .ResideInNamespace(nameof(Application))
            .ShouldNot()
            .HaveDependencyOn(nameof(Persistence))
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Application_Should_HaveNotDependencyOnApiService()
    {
        // Arrange
        var applicationAssembly = AssemblyReference.Assembly;

        // Act
        var result = Types.InAssembly(applicationAssembly)
            .That()
            .ResideInNamespace(nameof(Application))
            .ShouldNot()
            .HaveDependencyOn(nameof(ApiService))
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful);
    }
}