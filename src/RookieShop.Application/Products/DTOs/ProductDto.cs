﻿using RookieShop.Application.Categories.DTOs;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.Application.Products.DTOs;

public sealed record ProductDto(
    ProductId Id,
    string Name,
    string? Description,
    int Quantity,
    decimal Price,
    decimal PriceSale,
    IEnumerable<ProductImageDto>? ProductImages,
    CategoryDto? Category);