using Pgvector;

namespace RookieShop.Infrastructure.Ai.Embedded;

public interface IAiService
{
    ValueTask<Vector> GetEmbeddingAsync(string text, CancellationToken cancellationToken = default);

    ValueTask<IReadOnlyList<Vector>> GetEmbeddingsAsync(List<string> text, CancellationToken cancellationToken = default);
}