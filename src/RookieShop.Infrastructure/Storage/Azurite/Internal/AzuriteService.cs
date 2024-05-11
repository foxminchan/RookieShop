using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Polly;
using Polly.Retry;
using RookieShop.Infrastructure.Storage.Azurite.Settings;

namespace RookieShop.Infrastructure.Storage.Azurite.Internal;

public sealed class AzuriteService : IAzuriteService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly string? _containerName;

    private static readonly AsyncRetryPolicy _retryPolicy = Policy
        .Handle<RequestFailedException>()
        .WaitAndRetryAsync(3, attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)));

    public AzuriteService(AzuriteSettings azureSettings)
    {
        _blobServiceClient = new(azureSettings.ConnectionString);
        _containerName = azureSettings.ContainerName;
        _blobServiceClient.CreateBlobContainer(_containerName);
    }

    public async Task<string> UploadFileAsync(IFormFile file, CancellationToken cancellationToken = default)
    {
        var uniqueFileName = string.Concat(file.FileName, "-", Guid.NewGuid().ToString());

        var blobClient = _blobServiceClient.GetBlobContainerClient(_containerName)
            .GetBlobClient(uniqueFileName);

        await using var stream = file.OpenReadStream();
        var blobHttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType };

        await _retryPolicy.ExecuteAsync(async () =>
            await blobClient.UploadAsync(stream, blobHttpHeaders, cancellationToken: cancellationToken));

        return uniqueFileName;
    }

    public async Task DeleteFileAsync(string fileName, CancellationToken cancellationToken = default)
    {
        var blobClient = _blobServiceClient.GetBlobContainerClient(_containerName)
            .GetBlobClient(fileName);

        await _retryPolicy.ExecuteAsync(async () =>
            await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots,
                cancellationToken: cancellationToken));
    }
}