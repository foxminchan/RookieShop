using Ardalis.GuardClauses;
using Ardalis.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RookieShop.Application.Products.DTOs;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.ValueObjects;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.GenAi.OpenAi;
using RookieShop.Infrastructure.Storage.Azurite;

namespace RookieShop.Application.Products.Commands.Update;

public sealed class UpdateProductHandler(
    IRepository<Product> repository,
    IOpenAiService aiService,
    IAzuriteService azuriteService,
    ILogger<UpdateProductHandler> logger) : ICommandHandler<UpdateProductCommand, Result<ProductDto>>
{
    public async Task<Result<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await repository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, product);

        product.Update(
            request.Name,
            request.Description,
            request.Quantity,
            request.Price,
            request.PriceSale,
            request.CategoryId);

        product.Embedding =
            await aiService.GetEmbeddingAsync($"{product.Name} {product.Description}", cancellationToken);

        if (request.DeleteImageIds?.Any() == true && product.ProductImages?.Count != 0)
            await DeleteProductImagesAsync(product, request.DeleteImageIds, azuriteService, cancellationToken);

        var productImages = await AddProductImagesAsync(request.Images, product.Name, cancellationToken);

        product.AddImages(productImages);

        logger.LogInformation("Updating product: {ProductId}, {ProductName}", product.Id, product.Name);

        await repository.UpdateAsync(product, cancellationToken);

        return product.ToProductDto();
    }

    private async Task<List<ProductImage>?> AddProductImagesAsync(
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

    private static async Task DeleteProductImagesAsync(
        Product product,
        IEnumerable<ProductImageId> imageIdsToDelete,
        IAzuriteService azuriteService,
        CancellationToken cancellationToken)
    {
        foreach (var imageId in imageIdsToDelete)
        {
            var productImage = product.ProductImages?.FirstOrDefault(x => x.Id == imageId);

            if (productImage?.Name is not null)
                await azuriteService.DeleteFileAsync(productImage.Name, cancellationToken);

            product.DeleteImage(imageId);
        }
    }
}