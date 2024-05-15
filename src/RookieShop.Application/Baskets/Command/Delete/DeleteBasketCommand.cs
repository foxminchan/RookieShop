using Ardalis.Result;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Baskets.Command.Delete;

public sealed record DeleteBasketCommand(string AccountId) : ICommand<Result>;