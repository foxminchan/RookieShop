namespace RookieShop.FunctionalTests.ApiService;

public sealed class ProductsEndpointTest
{
    [Fact]
    public async Task GetProducts_ShouldBeOkStatusCode()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.RookieShop_ApiService>();
        await using var app = await appHost.BuildAsync();
        await app.StartAsync();

        // Act
        var httpClient = app.CreateHttpClient("api-service");
        var response = await httpClient.GetAsync("/api/v1/products");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GiveUnknownId_GetProducts_ShouldBeNotFoundStatusCode()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.RookieShop_ApiService>();
        await using var app = await appHost.BuildAsync();
        await app.StartAsync();
        var id = Guid.NewGuid().ToString();

        // Act
        var httpClient = app.CreateHttpClient("api-service");
        var response = await httpClient.GetAndEnsureNotFoundAsync($"/api/v1/products/{id}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}