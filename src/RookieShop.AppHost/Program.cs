using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var identityService = builder.AddProject<RookieShop_IdentityService>("identityservice");

var apiService = builder
    .AddProject<RookieShop_ApiService>("apiservice")
    .WithReference(identityService);

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