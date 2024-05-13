using Ardalis.GuardClauses;
using Ardalis.Result;
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Categories.Commands.Delete;

public sealed class DeleteCategoryHandler(IRepository<Category> repository)
    : ICommandHandler<DeleteCategoryCommand, Result>
{
    public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, category);

        await repository.DeleteAsync(category, cancellationToken);

        return Result.Success();
    }
}