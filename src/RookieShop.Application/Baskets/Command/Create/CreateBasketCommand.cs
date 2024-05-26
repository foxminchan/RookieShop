using Ardalis.Result;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Baskets.Command.Create;

public sealed record CreateBasketCommand(Guid AccountId, ProductId ProductId, int Quantity, decimal Price)
    : ICommand<Result<Guid>>;