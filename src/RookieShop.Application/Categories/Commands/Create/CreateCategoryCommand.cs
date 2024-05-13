using Ardalis.Result;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Categories.Commands.Create;

public sealed record CreateCategoryCommand(string Name, string? Description) : ICommand<Result<CategoryId>>;