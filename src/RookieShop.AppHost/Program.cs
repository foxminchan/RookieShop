using Microsoft.Extensions.Hosting;
using Projects;
using RookieShop.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddForwardedHeaders();

var protocol = "https";

// Secret parameters
var postgresUser = builder.AddParameter("SqlUser", true);
var postgresPassword = builder.AddParameter("SqlPassword", true);
var stripeApiKey = builder.AddParameter("StripeApiKey", true);
var stripeWebhookSecret = builder.AddParameter("StripeWebhookSecret", true);
var emailSecret = builder.AddParameter("EmailSecret", true);
var googleClientId = builder.AddParameter("GoogleClientId", true);
var googleClientSecret = builder.AddParameter("GoogleClientSecret", true);
var openAiKey = builder.AddParameter("OpenAiKey", true);

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
    .WithReference(userDb);

var apiService = builder
    .AddProject<RookieShop_ApiService>("api-service")
    .WithReference(redis)
    .WithReference(shopDb)
    .WithHttpEndpoint()
    .WithEnvironment("SmtpSettings__Secret", emailSecret)
    .WithEnvironment("AzuriteSettings__ConnectionString", blobs.WithEndpoint())
    .WithEnvironment("OpenIdSettings__Authority", identityService.GetEndpoint("https"));

var backoffice = builder
    .AddNpmApp("backoffice", "../../ui/backoffice", "dev")
    .WithHttpEndpoint(3000, env: "PORT")
    .WithEnvironment("BROWSER", "none")
    .WithEnvironment("NEXT_PUBLIC_BASE_API", $"{apiService.GetEndpoint(protocol)}/api/v1")
    .WithEnvironment("NEXT_PUBLIC_DUENDE_AUTHORITY", identityService.GetEndpoint("https"))
    .PublishAsDockerFile();

var storefront = builder
    .AddProject<RookieShop_Storefront>("storefront")
    .WithReference(redis)
    .WithHttpEndpoint(7090)
    .WithEnvironment("SmartComponents__ApiKey", openAiKey)
    .WithEnvironment("StripeSettings__StripeSecretKey", stripeApiKey)
    .WithEnvironment("StripeSettings__StripeWebhookSecret", stripeWebhookSecret)
    .WithEnvironment("OpenIdSettings__Authority", identityService.GetEndpoint("https"))
    .WithEnvironment("BaseApiEndpoint", $"{apiService.GetEndpoint(protocol)}/api/v1");

var bff = builder.AddProject<RookieShop_Bff>("BFF");

apiService
    .WithEnvironment("CorsSettings__Storefront", storefront.GetEndpoint(protocol))
    .WithEnvironment("CorsSettings__Backoffice", backoffice.GetEndpoint(protocol));

identityService
    .WithEnvironment("Provider__Google__ClientId", googleClientId)
    .WithEnvironment("Provider__Google__ClientSecret", googleClientSecret)
    .WithEnvironment("Client__Storefront", storefront.GetEndpoint(protocol))
    .WithEnvironment("Client__Swagger", apiService.GetEndpoint(protocol))
    .WithEnvironment("Client__Bff", bff.GetEndpoint("https"));

bff.WithEnvironment("BFF__Authority", identityService.GetEndpoint("https"));

await builder.Build().RunAsync();