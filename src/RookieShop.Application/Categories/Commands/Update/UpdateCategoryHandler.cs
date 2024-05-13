using System.Text.Json;
using Ardalis.GuardClauses;
using Ardalis.Result;
using Microsoft.Extensions.Logging;
using RookieShop.Application.Categories.DTOs;
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Categories.Commands.Update;

public sealed class UpdateCategoryHandler(IRepository<Category> repository, ILogger<UpdateCategoryHandler> logger)
    : ICommandHandler<UpdateCategoryCommand, Result<CategoryDto>>
{
    public async Task<Result<CategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, category);

        category.Update(request.Name, request.Description);

        logger.LogInformation("[{Command}] - Updating category {@Category}", nameof(UpdateCategoryCommand),
            JsonSerializer.Serialize(category));

        await repository.UpdateAsync(category, cancellationToken);

        return category.ToCategoryDto();
    }
}