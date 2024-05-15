using Ardalis.Result;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Baskets.Command.Create;

public sealed record CreateBasketCommand(Guid AccountId, List<BasketDetail> BasketDetails) : ICommand<Result<Guid>>;