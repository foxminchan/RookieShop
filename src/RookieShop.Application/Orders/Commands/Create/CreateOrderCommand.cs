using Ardalis.Result;
using RookieShop.Domain.Entities.OrderAggregator.Enums;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Orders.Commands.Create;

public sealed record CreateOrderCommand(
    PaymentMethod PaymentMethod,
    string? CardHolderName,
    string? Number,
    string? ExpiryYear,
    string? ExpiryMonth,
    string? Cvc,
    string? Street,
    string? City,
    string? Province,
    Guid AccountId) : ICommand<Result<OrderId>>;