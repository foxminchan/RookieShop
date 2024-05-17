using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Polly;
using Polly.Registry;

namespace RookieShop.Infrastructure.Storage.Azurite.Internal;

public sealed class AzuriteService(
    BlobServiceClient blobServiceClient,
    ResiliencePipelineProvider<string> pipelineProvider) : IAzuriteService
{
    private const string ContainerName = "rookieshop";

    private readonly ResiliencePipeline _policy = pipelineProvider.GetPipeline(nameof(Azurite));

    public async Task<string> UploadFileAsync(IFormFile file, CancellationToken cancellationToken = default)
    {
        var uniqueFileName = Guid.NewGuid().ToString();

        var blobClient = blobServiceClient.GetBlobContainerClient(ContainerName)
            .GetBlobClient(uniqueFileName);

        await _policy.ExecuteAsync(
            async token => await blobClient.UploadAsync(
                file.OpenReadStream(),
                new BlobHttpHeaders() { ContentType = file.ContentType },
                cancellationToken: token),
            cancellationToken);

        return uniqueFileName;
    }

    public async Task DeleteFileAsync(string fileName, CancellationToken cancellationToken = default)
    {
        var blobClient = blobServiceClient.GetBlobContainerClient(ContainerName)
            .GetBlobClient(fileName);

        await _policy.ExecuteAsync(
            async token =>
                await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots, cancellationToken: token),
            cancellationToken);
    }
}