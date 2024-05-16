using Ardalis.GuardClauses;
using Ardalis.Result;
using RookieShop.Domain.Entities.OrderAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Orders.Command.Delete;

public sealed class DeleteOrderHandler(IRepository<Order> repository) : ICommandHandler<DeleteOrderCommand, Result>
{
    public async Task<Result> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await repository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, order);

        await repository.DeleteAsync(order, cancellationToken);

        return Result.Success();
    }
}