using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RookieShop.ApiService.ViewModels.Products;
using RookieShop.Application.Products.Commands.Update;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.Enums;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Products;

public sealed class Update(ISender sender) : IEndpoint<Ok<UpdateProductResponse>, UpdateProductRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPut("/products",
                async (
                        [FromForm] ProductId id,
                        [FromForm] string name,
                        [FromForm] string? description,
                        [FromForm] int quantity,
                        [FromForm] decimal price,
                        [FromForm] decimal priceSale,
                        IFormFile? productImages,
                        [FromForm] ProductStatus status,
                        [FromForm] bool isDeletedOldImage = false,
                        [FromForm] CategoryId? categoryId = null)
                    => await HandleAsync(new(id, name, description, quantity, price, priceSale, status, productImages,
                        isDeletedOldImage, categoryId)))
            .DisableAntiforgery()
            .Produces<Ok<UpdateProductResponse>>()
            .Produces<NotFound<string>>(StatusCodes.Status404NotFound)
            .Produces<BadRequest<IEnumerable<ValidationError>>>(StatusCodes.Status400BadRequest)
            .WithTags(nameof(Products))
            .WithName("Update Product")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<Ok<UpdateProductResponse>> HandleAsync(UpdateProductRequest request,
        CancellationToken cancellationToken = default)
    {
        UpdateProductCommand command = new(
            request.Id,
            request.Name,
            request.Description,
            request.Quantity,
            request.Price,
            request.PriceSale,
            request.ProductImages,
            request.IsDeletedOldImage,
            request.CategoryId,
            request.Status);

        var result = await sender.Send(command, cancellationToken);

        UpdateProductResponse response = new(result.Value.ToProductVm());

        return TypedResults.Ok(response);
    }
}