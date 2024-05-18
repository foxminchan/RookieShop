using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RookieShop.ApiService.Filters;
using RookieShop.Application.Products.Commands.Create;
using RookieShop.Domain.Constants;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Products;

public sealed class Create(ISender sender) : IEndpoint<Created<CreateProductResponse>, CreateProductRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPost("/products", async (
                    [FromHeader(Name = HeaderName.IdempotencyKey)]
                    string key,
                    [FromForm] string name,
                    [FromForm] string? description,
                    [FromForm] int quantity,
                    [FromForm] decimal price,
                    [FromForm] decimal priceSale,
                    [FromForm] CategoryId? categoryId,
                    IFormFile? productImages) =>
                await HandleAsync(new(name, description, quantity, price, priceSale, productImages, categoryId)))
            .AddEndpointFilter<IdempotencyFilter>()
            .AddEndpointFilter<FileValidationFilter>()
            .DisableAntiforgery()
            .Produces<Created<CreateProductResponse>>(StatusCodes.Status201Created)
            .Produces<BadRequest<IEnumerable<ValidationError>>>(StatusCodes.Status400BadRequest)
            .WithTags(nameof(Products))
            .WithName("Create Product")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<Created<CreateProductResponse>> HandleAsync(CreateProductRequest request,
        CancellationToken cancellationToken = default)
    {
        CreateProductCommand command = new(
            request.Name,
            request.Description,
            request.Quantity,
            request.Price,
            request.PriceSale,
            request.ProductImages,
            request.CategoryId);

        var result = await sender.Send(command, cancellationToken);

        CreateProductResponse response = new(result.Value);

        return TypedResults.Created($"/api/products/{result.Value}", response);
    }
}