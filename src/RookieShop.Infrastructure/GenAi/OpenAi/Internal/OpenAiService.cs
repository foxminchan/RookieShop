using Microsoft.SemanticKernel.Embeddings;
using Pgvector;

namespace RookieShop.Infrastructure.GenAi.OpenAi.Internal;

public sealed class OpenAiService(ITextEmbeddingGenerationService embeddingGenerator) : IOpenAiService
{
    private const int EmbeddingDimensions = 384;

    public async ValueTask<Vector> GetEmbeddingAsync(string text, CancellationToken cancellationToken = default)
    {
        var embedding =
            await embeddingGenerator.GenerateEmbeddingAsync(text, cancellationToken: cancellationToken);

        embedding = embedding[..EmbeddingDimensions];

        return new(embedding);
    }

    public async ValueTask<IEnumerable<Vector>> GetEmbeddingsAsync(IEnumerable<string> texts,
        CancellationToken cancellationToken = default)
    {
        var embeddings =
            await embeddingGenerator.GenerateEmbeddingsAsync(texts.ToList(), cancellationToken: cancellationToken);

        var results = embeddings.Select(m => new Vector(m[..EmbeddingDimensions])).ToList();

        return results;
    }
}