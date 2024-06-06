using System.Text.Json;
using Ardalis.GuardClauses;
using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using RookieShop.Application.Categories.DTOs;
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Domain.Entities.CategoryAggregator.Events;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Categories.Commands.Update;

public sealed class UpdateCategoryHandler(
    IRepository<Category> repository,
    ILogger<UpdateCategoryHandler> logger,
    IPublisher publisher) : ICommandHandler<UpdateCategoryCommand, Result<CategoryDto>>
{
    public async Task<Result<CategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, category);

        category.Update(request.Name, request.Description);

        logger.LogInformation("[{Command}] - Updating category {@Category}", nameof(UpdateCategoryCommand),
            JsonSerializer.Serialize(category));

        await repository.UpdateAsync(category, cancellationToken);

        await publisher.Publish(
            new UpdatedCategoryEvent(category.Id, category.Name, category.Description),
            cancellationToken);

        return category.ToCategoryDto();
    }
}