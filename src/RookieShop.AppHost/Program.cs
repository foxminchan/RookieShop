using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis", 6379)
    .WithDataBindMount("../../mnt/redis");

var identityService = builder
    .AddProject<RookieShop_IdentityService>("identityservice")
    .WithReference(redis);

var apiService = builder
    .AddProject<RookieShop_ApiService>("apiservice")
    .WithReference(redis)
    .WithReference(identityService)
    .WithEnvironment("OpenIdSettings__Authority", identityService.GetEndpoint("https"));

builder.AddNpmApp("backoffice", "../../ui/backoffice", "dev")
    .WithEnvironment("BROWSER", "none")
    .WithReference(apiService)
    .WithReference(identityService)
    .WithHttpEndpoint(env: "PORT")
    .PublishAsDockerFile();

builder.AddProject<RookieShop_Storefront>("storefront")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(identityService);

builder.Build().Run();