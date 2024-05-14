using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Polly;
using Polly.Retry;

namespace RookieShop.Infrastructure.Storage.Azurite.Internal;

public sealed class AzuriteService(BlobServiceClient blobServiceClient) : IAzuriteService
{
    private const string ContainerName = "rookieshop";

    private readonly AsyncRetryPolicy _policy = Policy.Handle<Exception>()
        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

    public async Task<string> UploadFileAsync(IFormFile file, CancellationToken cancellationToken = default)
    {
        var uniqueFileName = Guid.NewGuid().ToString();

        var blobClient = blobServiceClient.GetBlobContainerClient(ContainerName)
            .GetBlobClient(uniqueFileName);

        await _policy.ExecuteAsync(async () =>
            await blobClient.UploadAsync(file.OpenReadStream(),
                new BlobHttpHeaders() { ContentType = file.ContentType }, cancellationToken: cancellationToken));

        return uniqueFileName;
    }

    public async Task DeleteFileAsync(string fileName, CancellationToken cancellationToken = default)
    {
        var blobClient = blobServiceClient.GetBlobContainerClient(ContainerName)
            .GetBlobClient(fileName);

        await _policy.ExecuteAsync(async () =>
            await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots,
                cancellationToken: cancellationToken));
    }
}