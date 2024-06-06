using Ardalis.GuardClauses;
using Ardalis.Result;
using MediatR;
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Domain.Entities.CategoryAggregator.Events;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Categories.Commands.Delete;

public sealed class DeleteCategoryHandler(IRepository<Category> repository, IPublisher publisher)
    : ICommandHandler<DeleteCategoryCommand, Result>
{
    public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await repository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, category);

        await repository.DeleteAsync(category, cancellationToken);

        await publisher.Publish(
            new DeletedCategoryEvent(category.Id),
            cancellationToken);

        return Result.Success();
    }
}