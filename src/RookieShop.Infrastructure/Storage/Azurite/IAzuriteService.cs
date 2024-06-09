using Microsoft.AspNetCore.Http;

namespace RookieShop.Infrastructure.Storage.Azurite;

public interface IAzuriteService
{
    Task<string> UploadFileAsync(IFormFile file, CancellationToken cancellationToken = default);
    Task DeleteFileAsync(string fileName, CancellationToken cancellationToken = default);
    string? GetFileUrl(string? fileName);
}   