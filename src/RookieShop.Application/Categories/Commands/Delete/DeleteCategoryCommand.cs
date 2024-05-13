using Ardalis.Result;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Categories.Commands.Delete;

public sealed record DeleteCategoryCommand(CategoryId Id) : ICommand<Result>;