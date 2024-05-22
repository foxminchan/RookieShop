using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis", 6379)
    .WithDataBindMount("../../mnt/redis");

var identityService = builder
    .AddProject<RookieShop_IdentityService>("identity-service")
    .WithReference(redis);

var apiService = builder
    .AddProject<RookieShop_ApiService>("api-service")
    .WithReference(redis)
    .WithReference(identityService)
    .WithEnvironment("OpenIdSettings__Authority", identityService.GetEndpoint("https"))
    .WithReplicas(2);

builder.AddNpmApp("backoffice", "../../ui/backoffice", "dev")
    .WithEnvironment("BROWSER", "none")
    .WithReference(apiService)
    .WithReference(identityService)
    .WithHttpEndpoint(env: "PORT")
    .PublishAsDockerFile();

builder.AddProject<RookieShop_Storefront>("storefront")
    .WithExternalHttpEndpoints()
    .WithReference(redis)
    .WithReference(apiService)
    .WithReference(identityService)
    .WithEnvironment("OpenIdSettings__Authority", identityService.GetEndpoint("https"))
    .WithEnvironment("BaseApiEndpoint", $"{apiService.GetEndpoint("https")}/api/v1");

builder.Build().Run();