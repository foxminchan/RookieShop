namespace RookieShop.FunctionalTests.ApiService;

public sealed class CategoriesEndpointTest
{
    [Fact]
    public async Task GetCategories_ShouldBeOkStatusCode()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.RookieShop_ApiService>();
        await using var app = await appHost.BuildAsync();
        await app.StartAsync();

        // Act
        var httpClient = app.CreateHttpClient("api-service");
        var response = await httpClient.GetAsync("/api/v1/categories");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GiveUnknownId_GetCategories_ShouldBeNotFoundStatusCode()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.RookieShop_ApiService>();
        await using var app = await appHost.BuildAsync();
        await app.StartAsync();
        var id = Guid.NewGuid().ToString();

        // Act
        var httpClient = app.CreateHttpClient("api-service");
        var response = await httpClient.GetAndEnsureNotFoundAsync($"/api/v1/categories/{id}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GiveNullDataAndUnAuthorize_PostCategories_ShouldBeBadRequestStatusCode()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.RookieShop_ApiService>();
        await using var app = await appHost.BuildAsync();
        await app.StartAsync();

        // Act
        var httpClient = app.CreateHttpClient("api-service");
        var response = await httpClient.PostAndEnsureUnauthorizedAsync("/api/v1/categories", null);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GiveNullDataAndAuthorize_DeleteCategories_ShouldBeBadRequestStatusCode()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.RookieShop_ApiService>();
        await using var app = await appHost.BuildAsync();
        await app.StartAsync();
        var id = Guid.NewGuid().ToString();

        // Act
        var httpClient = app.CreateHttpClient("api-service");
        var response = await httpClient.DeleteAndEnsureUnauthorizedAsync($"/api/v1/categories/{id}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}