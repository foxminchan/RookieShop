namespace RookieShop.Application.Products.DTOs;

public sealed record ProductImageDto(
    string ImageUrl,
    string? ImageAlt,
    bool IsDefault);