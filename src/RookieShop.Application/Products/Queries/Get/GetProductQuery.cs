using Ardalis.Result;
using RookieShop.Application.Products.DTOs;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Products.Queries.Get;

public sealed record GetProductQuery(ProductId Id) : IQuery<Result<ProductDto>>;