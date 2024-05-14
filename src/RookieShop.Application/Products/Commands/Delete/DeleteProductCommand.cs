using Ardalis.Result;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Products.Commands.Delete;

public sealed record DeleteProductCommand(ProductId Id) : ICommand<Result>;