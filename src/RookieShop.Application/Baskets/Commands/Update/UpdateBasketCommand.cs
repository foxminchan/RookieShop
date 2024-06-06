using Ardalis.Result;
using RookieShop.Application.Baskets.DTOs;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Baskets.Commands.Update;

public sealed record UpdateBasketCommand(Guid AccountId, ProductId ProductId, int Quantity)
    : ICommand<Result<BasketDto>>;