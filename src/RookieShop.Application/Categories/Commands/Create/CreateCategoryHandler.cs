using System.Text.Json;
using Ardalis.Result;
using Microsoft.Extensions.Logging;
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Categories.Commands.Create;

public sealed class CreateCategoryHandler(IRepository<Category> repository, ILogger<CreateCategoryHandler> logger)
    : ICommandHandler<CreateCategoryCommand, Result<CategoryId>>
{
    public async Task<Result<CategoryId>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = new(request.Name, request.Description);

        logger.LogInformation("[{Command}] - Creating category {@Category}", nameof(CreateCategoryCommand),
            JsonSerializer.Serialize(category));

        var result = await repository.AddAsync(category, cancellationToken);

        return result.Id;
    }
}