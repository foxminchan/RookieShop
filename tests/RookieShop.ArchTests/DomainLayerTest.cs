using System.Reflection;
using RookieShop.Domain;
using RookieShop.Domain.SeedWork;

namespace RookieShop.ArchTests;

public sealed class DomainLayerTest
{
    [Fact]
    public void DomainLayer_Should_BeSealed()
    {
        // Arrange
        var assembly = AssemblyReference.Assembly;

        // Act
        var result = Types.InAssembly(assembly)
            .That()
            .AreNotNestedPrivate()
            .And()
            .HaveNameEndingWith(nameof(Domain))
            .Should()
            .BeSealed()
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Entities_Should_HavePublicParameterlessConstructor()
    {
        // Arrange
        var entityType = Types.InAssembly(AssemblyReference.Assembly)
            .That()
            .Inherit(typeof(EntityBase))
            .GetTypes();

        // Act
        var failingTypes = entityType.Where(type =>
            Array.Find(type.GetConstructors(BindingFlags.Public | BindingFlags.Instance),
                c => c.GetParameters().Length == 0) is null
        ).ToList();

        // Assert
        failingTypes.Should().BeEmpty();
    }

    [Fact]
    public void Domain_Should_NotHaveDependencyOnApplication()
    {
        // Arrange
        var domainAssembly = AssemblyReference.Assembly;

        // Act
        var result = Types.InAssembly(domainAssembly)
            .That()
            .ResideInNamespace(nameof(Domain))
            .ShouldNot()
            .HaveDependencyOn(nameof(Application))
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
}