using Ardalis.GuardClauses;
using Ardalis.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RookieShop.Application.Products.DTOs;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Storage.Azurite;

namespace RookieShop.Application.Products.Commands.Update;

public sealed class UpdateProductHandler(
    IRepository<Product> repository,
    IAzuriteService azuriteService,
    ILogger<UpdateProductHandler> logger) : ICommandHandler<UpdateProductCommand, Result<ProductDto>>
{
    public async Task<Result<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await repository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, product);

        if (request.DeleteOldImage && product.ImageName is not null)
        {
            await azuriteService.DeleteFileAsync(product.ImageName, cancellationToken);
            product.ImageName = null;
        }

        var productImage = request.Image is not null
            ? await UploadProductImagesAsync(request.Image, cancellationToken)
            : product.ImageName;

        product.Update(
            request.Name,
            request.Description,
            request.Quantity,
            request.Price,
            request.PriceSale,
            productImage,
            request.CategoryId);

        logger.LogInformation("Updating product: {ProductId}, {ProductName}", product.Id, product.Name);

        await repository.UpdateAsync(product, cancellationToken);

        return product.ToProductDto();
    }

    private async Task<string?> UploadProductImagesAsync(IFormFile? imageFile, CancellationToken cancellationToken)
    {
        if (imageFile is null)
            return null;

        var imageUrl = await azuriteService.UploadFileAsync(imageFile, cancellationToken);

        return imageUrl;
    }
}