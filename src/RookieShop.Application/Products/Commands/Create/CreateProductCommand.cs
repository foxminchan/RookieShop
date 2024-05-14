using Ardalis.Result;
using Microsoft.AspNetCore.Http;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Products.Commands.Create;

public sealed record CreateProductCommand(
    string Name,
    string? Description,
    int Quantity,
    decimal Price,
    decimal PriceSale,
    IFormFile? ProductImages,
    CategoryId? CategoryId) : ICommand<Result<ProductId>>;