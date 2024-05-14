using System.Text.Json;
using Ardalis.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.GenAi.OpenAi;
using RookieShop.Infrastructure.Storage.Azurite;

namespace RookieShop.Application.Products.Commands.Create;

public sealed class CreateProductHandler(
    IRepository<Product> repository,
    IOpenAiService aiService,
    IAzuriteService azuriteService,
    ILogger<CreateProductHandler> logger) : ICommandHandler<CreateProductCommand, Result<ProductId>>
{
    public async Task<Result<ProductId>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productImage = await UploadProductImagesAsync(request.ProductImages, cancellationToken);

        Product product = new(
            request.Name,
            request.Description,
            request.Quantity,
            request.Price,
            request.PriceSale,
            productImage,
            request.CategoryId);

        product.Embedding =
            await aiService.GetEmbeddingAsync($"{product.Name} {product.Description}", cancellationToken);

        logger.LogInformation("[{Command}] - Creating product {@Product}", nameof(CreateProductCommand),
            JsonSerializer.Serialize(product));

        var result = await repository.AddAsync(product, cancellationToken);

        return result.Id;
    }

    private async Task<string?> UploadProductImagesAsync(IFormFile? imageFile, CancellationToken cancellationToken)
    {
        if (imageFile is null)
            return null;

        var imageUrl = await azuriteService.UploadFileAsync(imageFile, cancellationToken);

        return imageUrl;
    }
}