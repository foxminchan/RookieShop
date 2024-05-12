using RookieShop.Infrastructure;

namespace RookieShop.ArchTests;

public sealed class InfrastructureLayerTest
{
    [Fact]
    public void Infrastructure_Should_HaveDependencyOnDomain()
    {
        // Arrange
        var infrastructureAssembly = AssemblyReference.Assembly;

        // Act
        var result = Types.InAssembly(infrastructureAssembly)
            .That()
            .ResideInNamespace(nameof(Infrastructure))
            .Should()
            .HaveDependencyOn(nameof(Domain))
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Infrastructure_Should_HaveNotDependencyOnPersistence()
    {
        // Arrange
        var infrastructureAssembly = AssemblyReference.Assembly;

        // Act
        var result = Types.InAssembly(infrastructureAssembly)
            .That()
            .ResideInNamespace(nameof(Infrastructure))
            .ShouldNot()
            .HaveDependencyOn(nameof(Persistence))
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful);
    }
}