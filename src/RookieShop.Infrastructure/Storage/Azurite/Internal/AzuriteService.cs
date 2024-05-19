using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Polly;
using Polly.Retry;
using RookieShop.Infrastructure.Storage.Azurite.Settings;

namespace RookieShop.Infrastructure.Storage.Azurite.Internal;

public sealed class AzuriteService(AzuriteSettings option) : IAzuriteService
{
    private readonly AsyncRetryPolicy _policy = Policy
        .Handle<Exception>()
        .WaitAndRetryAsync(3, attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)));

    private readonly BlobContainerClient _container = new(option.ConnectionString, option.ContainerName);

    public async Task<string> UploadFileAsync(IFormFile file, CancellationToken cancellationToken = default)
    {
        await _container.CreateIfNotExistsAsync(cancellationToken: cancellationToken);

        var blobName = Guid.NewGuid().ToString();

        var blobClient = _container.GetBlobClient(blobName);

        await _policy.ExecuteAsync(async () => await blobClient.UploadAsync(file.OpenReadStream(),
            new BlobHttpHeaders() { ContentType = file.ContentType }, cancellationToken: cancellationToken));

        return blobName;
    }

    public async Task DeleteFileAsync(string fileName, CancellationToken cancellationToken = default)
    {
        var blobClient = _container.GetBlobClient(fileName);

        await _policy.ExecuteAsync(
            async () => await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots,
                cancellationToken: cancellationToken));
    }
}