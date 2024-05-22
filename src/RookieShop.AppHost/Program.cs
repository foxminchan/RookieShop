using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var identyService = builder.AddProject<RookieShop_IdentityService>("identityservice");

var apiService = builder
    .AddProject<RookieShop_ApiService>("apiservice")
    .WithReference(identyService);

builder.AddProject<RookieShop_Storefront>("storefront")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(identyService);

builder.Build().Run();