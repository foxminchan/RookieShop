using RookieShop.ApiService;
using RookieShop.ApiService.Endpoints.Categories;
using RookieShop.IntegrationTests.Extensions;
using RookieShop.IntegrationTests.Fakers;
using RookieShop.IntegrationTests.Fixtures;

namespace RookieShop.IntegrationTests.Endpoints.Categories;

public sealed class TestGetCategoriesEndpoint(ApplicationFactory<Program> factory, ITestOutputHelper output)
    : IClassFixture<ApplicationFactory<Program>>, IAsyncLifetime
{
    private readonly ApplicationFactory<Program> _factory = factory.WithDbContainer();

    private readonly CategoryFaker _faker = new();

    public async Task InitializeAsync() => await _factory.StartContainersAsync();

    public async Task DisposeAsync() => await _factory.StopContainersAsync();

    [Fact]
    public async Task ShouldBeReturnCategories()
    {
        // Arrange
        var client = _factory.CreateClient();
        var categories = _faker.Generate(10);

        // Act
        await _factory.EnsureCreatedAndPopulateDataAsync(categories);
        var response = await client.GetAndDeserializeAsync<ListCategoriesResponse>("/api/v1/categories");

        // Assert
        output.WriteLine("Response: {0}", response);
        response.Should().NotBeNull();
        response.Categories?.Count.Should().Be(categories.Count);
    }
}