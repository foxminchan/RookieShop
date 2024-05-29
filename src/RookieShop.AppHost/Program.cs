using Microsoft.Extensions.Hosting;
using Projects;
using RookieShop.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddForwardedHeaders();

var protocol = "https";

// Secret parameters
var postgresUser = builder.AddParameter("SqlUser", secret: true);
var postgresPassword = builder.AddParameter("SqlPassword", secret: true);
var stripeApiKey = builder.AddParameter("StripeApiKey", secret: true);
var emailSecret = builder.AddParameter("EmailSecret", secret: true);
var googleClientId = builder.AddParameter("GoogleClientId", secret: true);
var googleClientSecret = builder.AddParameter("GoogleClientSecret", secret: true);

// Postgres database
var db = builder
    .AddPostgres("db", postgresUser, postgresPassword, 5432)
    .WithDataBindMount("../../mnt/postgres")
    .WithPgAdmin();
var shopDb = db.AddDatabase("shopdb");
var userDb = db.AddDatabase("userdb");

// Redis cache
var redis = builder.AddRedis("redis", 6379)
    .WithDataBindMount("../../mnt/redis");

// Azure Storage
var storage = builder.AddAzureStorage("storage");

if (builder.Environment.IsDevelopment())
{
    protocol = "http";
    storage.RunAsEmulator(config => config.WithDataBindMount("../../mnt/azurite"));
}

var blobs = storage.AddBlobs("blobs");

// Services and applications
var identityService = builder
    .AddProject<RookieShop_IdentityService>("identity-service")
    .WithReference(redis)
    .WithReference(userDb)
    .WithHttpEndpoint();

var apiService = builder
    .AddProject<RookieShop_ApiService>("api-service")
    .WithReference(redis)
    .WithReference(shopDb)
    .WithHttpEndpoint()
    .WithEnvironment("StripeSettings__SecretKey", stripeApiKey)
    .WithEnvironment("SmtpSettings__Secret", emailSecret)
    .WithEnvironment("AzuriteSettings__ConnectionString", blobs.WithEndpoint())
    .WithEnvironment("OpenIdSettings__Authority", identityService.GetEndpoint(protocol));

var backoffice = builder
    .AddNpmApp("backoffice", "../../ui/backoffice", "dev")
    .WithHttpEndpoint(env: "PORT")
    .WithEnvironment("BROWSER", "none")
    .WithEnvironment("NEXT_PUBLIC_BASE_API", $"{apiService.GetEndpoint(protocol)}/api/v1")
    .WithEnvironment("AUTH_DUENDE_IDENTITY_SERVER6_ISSUER", identityService.GetEndpoint(protocol))
    .PublishAsDockerFile();

var storefront = builder
    .AddProject<RookieShop_Storefront>("storefront")
    .WithReference(redis)
    .WithHttpEndpoint()
    .WithEnvironment("OpenIdSettings__Authority", identityService.GetEndpoint(protocol))
    .WithEnvironment("BaseApiEndpoint", $"{apiService.GetEndpoint(protocol)}/api/v1");

apiService
    .WithEnvironment("CorsSettings__Storefront", storefront.GetEndpoint(protocol))
    .WithEnvironment("CorsSettings__Backoffice", backoffice.GetEndpoint(protocol));

identityService
    .WithEnvironment("Provider__Google__ClientId", googleClientId)
    .WithEnvironment("Provider__Google__ClientSecret", googleClientSecret)
    .WithEnvironment("Client__Backoffice", backoffice.GetEndpoint(protocol))
    .WithEnvironment("Client__Storefront", storefront.GetEndpoint(protocol))
    .WithEnvironment("Client__Swagger", apiService.GetEndpoint(protocol));

builder.Build().Run();