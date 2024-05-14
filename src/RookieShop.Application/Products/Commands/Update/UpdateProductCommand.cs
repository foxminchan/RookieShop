﻿using Ardalis.Result;
using Microsoft.AspNetCore.Http;
using RookieShop.Application.Products.DTOs;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Products.Commands.Update;

public sealed record UpdateProductCommand(
    ProductId Id,
    string Name,
    string? Description,
    int Quantity,
    decimal Price,
    decimal PriceSale,
    IFormFileCollection? Images,
    IEnumerable<ProductImageId>? DeleteImageIds,
    CategoryId CategoryId = default) : ICommand<Result<ProductDto>>;