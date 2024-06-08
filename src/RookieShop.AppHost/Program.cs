using Microsoft.Extensions.Hosting;
using Projects;
using RookieShop.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddForwardedHeaders();

const string protocol = "https";

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
    storage.RunAsEmulator(config => config.WithDataBindMount("../../mnt/azurite"));
}

var blobs = storage.AddBlobs("blobs");

// Services and applications
var identityService = builder
    .AddProject<RookieShop_IdentityService>("identity-service")
    .WithReference(redis)
    .WithReference(userDb);

var bff = builder.AddProject<RookieShop_Bff>("bff");

var apiService = builder
    .AddProject<RookieShop_ApiService>("api-service")
    .WithReference(redis)
    .WithReference(shopDb)
    .WithEnvironment("SmtpSettings__Secret", emailSecret)
    .WithEnvironment("AzuriteSettings__ConnectionString", blobs.WithEndpoint())
    .WithEnvironment("OpenIdSettings__Authority", identityService.GetEndpoint(protocol));

var backoffice = builder
    .AddNpmApp("backoffice", "../../ui/backoffice", "dev:ssl")
    .WithHttpEndpoint(3000, env: "PORT")
    .WithEnvironment("BROWSER", "none")
    .WithEnvironment("NEXT_PUBLIC_REMOTE_BFF", bff.GetEndpoint(protocol))
    .PublishAsDockerFile();

var storefront = builder
    .AddProject<RookieShop_Storefront>("storefront")
    .WithReference(redis)
    .WithEnvironment("SmartComponents__ApiKey", openAiKey)
    .WithEnvironment("StripeSettings__StripeSecretKey", stripeApiKey)
    .WithEnvironment("StripeSettings__StripeWebhookSecret", stripeWebhookSecret)
    .WithEnvironment("OpenIdSettings__Authority", identityService.GetEndpoint(protocol))
    .WithEnvironment("BaseApiEndpoint", $"{apiService.GetEndpoint(protocol)}/api/v1");

apiService
    .WithEnvironment("CorsSettings__Storefront", storefront.GetEndpoint(protocol))
    .WithEnvironment("CorsSettings__Backoffice", backoffice.GetEndpoint("http"));

identityService
    .WithEnvironment("Provider__Google__ClientId", googleClientId)
    .WithEnvironment("Provider__Google__ClientSecret", googleClientSecret)
    .WithEnvironment("Client__Storefront", storefront.GetEndpoint(protocol))
    .WithEnvironment("Client__Backoffice", backoffice.GetEndpoint("http"))
    .WithEnvironment("Client__Swagger", apiService.GetEndpoint(protocol))
    .WithEnvironment("Client__Bff", bff.GetEndpoint(protocol));

bff
    .WithReference(redis)
    .WithEnvironment("BFF__Authority", identityService.GetEndpoint(protocol))
    .WithEnvironment(
        "ReverseProxy__Clusters__api__Destinations__api__Address",
        $"{apiService.GetEndpoint(protocol)}/api/v1")
    .WithEnvironment("BFF__Api__RemoteUrl", $"{apiService.GetEndpoint(protocol)}/api/v1/categories");

await builder.Build().RunAsync();