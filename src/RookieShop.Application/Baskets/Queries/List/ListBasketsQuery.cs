using Ardalis.Result;
using RookieShop.Application.Baskets.DTOs;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Baskets.Queries.List;

public sealed record ListBasketsQuery : IQuery<Result<IEnumerable<BasketDto>>>;