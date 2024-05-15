using Ardalis.Result;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Baskets.Command.Update;

public sealed record UpdateBasketCommand(string AccountId, List<BasketDetail> BasketDetails) : ICommand<Result<Basket>>;