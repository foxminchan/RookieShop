namespace RookieShop.Application.Baskets.DTOs;

public sealed record BasketDto(
    Guid AccountId,
    decimal TotalPrice,
    List<BasketDetailDto> BasketDetails);