using System.Text.Json;
using Ardalis.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.ValueObjects;
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
        var productImages = await UploadProductImagesAsync(request.ProductImages, request.Name, cancellationToken);

        var product = Product.Factory.Create(
            request.Name,
            request.Description,
            request.Quantity,
            request.Price,
            request.PriceSale,
            productImages,
            request.CategoryId);

        product.Embedding =
            await aiService.GetEmbeddingAsync($"{product.Name} {product.Description}", cancellationToken);

        logger.LogInformation("[{Command}] - Creating product {@Product}", nameof(CreateProductCommand),
            JsonSerializer.Serialize(product));

        var result = await repository.AddAsync(product, cancellationToken);

        return result.Id;
    }

    private async Task<List<ProductImage>?> UploadProductImagesAsync(
        IReadOnlyCollection<IFormFile>? imageFiles,
        string productName,
        CancellationToken cancellationToken)
    {
        if (imageFiles is null || imageFiles.Count == 0)
            return null;

        var productImages = new List<ProductImage>();

        foreach (var imageFile in imageFiles)
        {
            var imageUrl = await azuriteService.UploadFileAsync(imageFile, cancellationToken);

            productImages.Add(
                productImages.Count == 0
                    ? ProductImage.Create(imageUrl, productName, true)
                    : ProductImage.Create(imageUrl, productName)
            );
        }

        return productImages;
    }
}