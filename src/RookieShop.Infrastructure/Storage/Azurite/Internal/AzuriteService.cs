using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Polly;
using Polly.Retry;

namespace RookieShop.Infrastructure.Storage.Azurite.Internal;

public sealed class AzuriteService(BlobServiceClient blobServiceClient) : IAzuriteService
{
    private const string ContainerName = "rookie-shop";

    private static readonly AsyncRetryPolicy _retryPolicy = Policy
        .Handle<RequestFailedException>()
        .WaitAndRetryAsync(3, attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)));

    public async Task<string> UploadFileAsync(IFormFile file, CancellationToken cancellationToken = default)
    {
        var uniqueFileName = string.Concat(file.FileName, "-", Guid.NewGuid().ToString());

        var blobClient = blobServiceClient.GetBlobContainerClient(ContainerName)
            .GetBlobClient(uniqueFileName);

        await using var stream = file.OpenReadStream();

        var blobHttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType };

        await _retryPolicy.ExecuteAsync(async () =>
            await blobClient.UploadAsync(stream, blobHttpHeaders, cancellationToken: cancellationToken));

        return uniqueFileName;
    }

    public async Task DeleteFileAsync(string fileName, CancellationToken cancellationToken = default)
    {
        var blobClient = blobServiceClient.GetBlobContainerClient(ContainerName)
            .GetBlobClient(fileName);

        await _retryPolicy.ExecuteAsync(async () =>
            await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots,
                cancellationToken: cancellationToken));
    }
}