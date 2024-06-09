using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Polly;
using Polly.Registry;
using RookieShop.Infrastructure.Storage.Azurite.Settings;

namespace RookieShop.Infrastructure.Storage.Azurite.Internal;

public sealed class AzuriteService(AzuriteSettings azuriteSettings, ResiliencePipelineProvider<string> pipeline)
    : IAzuriteService
{
    private readonly ResiliencePipeline _policy = pipeline.GetPipeline(nameof(Azurite));

    private readonly BlobContainerClient _container = new(azuriteSettings.ConnectionString,
        azuriteSettings.ContainerName);

    public async Task<string> UploadFileAsync(IFormFile file, CancellationToken cancellationToken = default)
    {
        await _container.CreateIfNotExistsAsync(cancellationToken: cancellationToken);

        var blobName = Guid.NewGuid().ToString();

        var blobClient = _container.GetBlobClient(blobName);

        await _policy.ExecuteAsync(
            async token => await blobClient.UploadAsync(
                file.OpenReadStream(),
                new BlobHttpHeaders() { ContentType = file.ContentType },
                cancellationToken: token),
            cancellationToken);

        return blobName;
    }

    public async Task DeleteFileAsync(string fileName, CancellationToken cancellationToken = default)
    {
        var blobClient = _container.GetBlobClient(fileName);

        await _policy.ExecuteAsync(
            async token =>
                await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots, cancellationToken: token),
            cancellationToken);
    }

    public string? GetFileUrl(string? fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            return null;

        var blobClient = _container.GetBlobClient(fileName);

        return blobClient.Uri.ToString();
    }
}