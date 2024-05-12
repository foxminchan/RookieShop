using Pgvector;

namespace RookieShop.Infrastructure.GenAi.OpenAi;

public interface IOpenAiService
{
    ValueTask<Vector> GetEmbeddingAsync(string text, CancellationToken cancellationToken = default);
    ValueTask<IEnumerable<Vector>> GetEmbeddingsAsync(IEnumerable<string> texts, CancellationToken cancellationToken = default);
}