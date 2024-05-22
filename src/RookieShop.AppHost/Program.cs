using Projects;
using RookieShop.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddForwardedHeaders();

var redis = builder.AddRedis("redis", 6379)
    .WithDataBindMount("../../mnt/redis");

var identityService = builder
    .AddProject<RookieShop_IdentityService>("identity-service")
    .WithReference(redis);

var apiService = builder
    .AddProject<RookieShop_ApiService>("api-service")
    .WithReference(redis)
    .WithEnvironment("OpenIdSettings__Authority", identityService.GetEndpoint("https"))
    .WithReplicas(2);

var backoffice = builder.AddNpmApp("backoffice", "../../ui/backoffice", "dev")
    .WithEnvironment("BROWSER", "none")
    .WithHttpEndpoint(env: "PORT")
    .WithEnvironment("BASE_API", $"{apiService.GetEndpoint("https")}/api/v1")
    .WithEnvironment("AUTH_DUENDE_IDENTITY_SERVER6_ISSUER", identityService.GetEndpoint("https"))
    .PublishAsDockerFile();

var storefront = builder.AddProject<RookieShop_Storefront>("storefront")
    .WithExternalHttpEndpoints()
    .WithReference(redis)
    .WithEnvironment("OpenIdSettings__Authority", identityService.GetEndpoint("https"))
    .WithEnvironment("BaseApiEndpoint", $"{apiService.GetEndpoint("https")}/api/v1");

identityService
    .WithEnvironment("Client__Backoffice", backoffice.GetEndpoint("http"))
    .WithEnvironment("Client__Storefront", storefront.GetEndpoint("https"))
    .WithEnvironment("Client__Swagger", apiService.GetEndpoint("https"));

builder.Build().Run();