using Ardalis.Result;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Products.Queries.CheckStock;

public sealed record CheckStockQuery(List<ProductInfo> Requests) : IQuery<Result<bool>>;

public sealed record ProductInfo(ProductId Id, int Quantity);