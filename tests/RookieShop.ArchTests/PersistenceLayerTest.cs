using RookieShop.Persistence;

namespace RookieShop.ArchTests;

public sealed class PersistenceLayerTest
{
    [Fact]
    public void Persistence_Should_HaveDependencyOnDomain()
    {
        // Arrange
        var persistenceAssembly = AssemblyReference.Assembly;

        // Act
        var result = Types.InAssembly(persistenceAssembly)
            .That()
            .ResideInNamespace(nameof(Persistence))
            .Should()
            .HaveDependencyOn(nameof(Domain))
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Persistence_Should_HaveDependencyOnInfrastructure()
    {
        // Arrange
        var persistenceAssembly = AssemblyReference.Assembly;

        // Act
        var result = Types.InAssembly(persistenceAssembly)
            .That()
            .ResideInNamespace(nameof(Persistence))
            .Should()
            .HaveDependencyOn(nameof(Infrastructure))
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Persistence_Should_HaveNotDependencyOnApplication()
    {
        // Arrange
        var persistenceAssembly = AssemblyReference.Assembly;

        // Act
        var result = Types.InAssembly(persistenceAssembly)
            .That()
            .ResideInNamespace(nameof(Persistence))
            .ShouldNot()
            .HaveDependencyOn(nameof(Application))
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void ApplicationDbContext_Should_HaveBeInPersistenceLayer()
    {
        // Arrange
        var assembly = AssemblyReference.Assembly;

        // Act
        var result = Types
            .InAssembly(assembly)
            .That()
            .ResideInNamespace(nameof(Persistence))
            .Should()
            .HaveName(nameof(ApplicationDbContext))
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue(result.ToString());
    }
}