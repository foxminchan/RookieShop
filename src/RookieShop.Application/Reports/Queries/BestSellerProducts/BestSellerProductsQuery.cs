using Ardalis.Result;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Reports.Queries.BestSellerProducts;

public sealed record BestSellerProductsQuery(int Top, DateTime? From, DateTime? To)
    : IQuery<Result<IEnumerable<BestSellerProductsDto>>>;