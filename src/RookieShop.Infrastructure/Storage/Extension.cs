using Ardalis.GuardClauses;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieShop.Infrastructure.Storage.Azurite;
using RookieShop.Infrastructure.Storage.Azurite.Internal;

namespace RookieShop.Infrastructure.Storage;

public static class Extension
{
    public static IHostApplicationBuilder AddStorage(this IHostApplicationBuilder builder)
    {
        var conn = builder.Configuration.GetConnectionString("Azurite");

        Guard.Against.Null(conn);

        builder.Services.AddSingleton<IAzuriteService, AzuriteService>();

        builder.Services.AddSingleton(_ => new BlobServiceClient(conn));

        return builder;
    }
}