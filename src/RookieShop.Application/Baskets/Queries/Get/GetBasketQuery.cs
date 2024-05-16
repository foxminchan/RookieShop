using Ardalis.Result;
using RookieShop.Application.Baskets.DTOs;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Baskets.Queries.Get;

public sealed record GetBasketQuery(Guid AccountId) : IQuery<Result<BasketDto>>;