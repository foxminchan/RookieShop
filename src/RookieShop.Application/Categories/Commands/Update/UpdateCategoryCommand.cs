using Ardalis.Result;
using RookieShop.Application.Categories.DTOs;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Categories.Commands.Update;

public sealed record UpdateCategoryCommand(CategoryId Id, string Name, string? Description)
    : ICommand<Result<CategoryDto>>;