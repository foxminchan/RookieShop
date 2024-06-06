using System.Text.Json;
using Ardalis.GuardClauses;
using Ardalis.Result;
using Medallion.Threading;
using Microsoft.Extensions.Logging;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.CustomerAggregator.Specifications;
using RookieShop.Domain.Entities.OrderAggregator;
using RookieShop.Domain.Entities.OrderAggregator.Enums;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Cache.Redis;

namespace RookieShop.Application.Orders.Commands.Create;

public sealed class CreateOrderHandler(
    IRedisService redisService,
    IRepository<Order> orderRepository,
    IReadRepository<Customer> customerRepository,
    IDistributedLockProvider distributedLockProvider,
    ILogger<CreateOrderHandler> logger) : ICommandHandler<CreateOrderCommand, Result<OrderId>>
{
    public async Task<Result<OrderId>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var customer =
            await customerRepository.FirstOrDefaultAsync(new CustomerByIdSpec(request.AccountId), cancellationToken);
        Guard.Against.NotFound(request.AccountId, customer);

        var basket = await redisService.HashGetAsync<Basket>(nameof(Basket), request.AccountId.ToString());
        Guard.Against.NotFound(request.AccountId, basket);

        var orderDetails = basket.BasketDetails
            .Select(detail => new OrderDetail(detail.Id, detail.Quantity, detail.Price)).ToList();

        Order order;

        await using (await distributedLockProvider.TryAcquireLockAsync(request.AccountId.ToString(),
                         cancellationToken: cancellationToken))
        {
            var newOrder = Order.Factory.Create(
                request.PaymentMethod,
                request.Last4,
                request.BrandName,
                request.ChargeId,
                request.Street,
                request.City,
                request.Province,
                customer.Id, OrderStatus.Pending,
                orderDetails);

            logger.LogInformation(
                "[{Command}] - Creating order for account {AccountId} with {@Order}",
                nameof(CreateOrderCommand), request.AccountId, JsonSerializer.Serialize(newOrder));

            newOrder.AddOrderDetail(request.AccountId, newOrder, customer.Email);

            order = await orderRepository.AddAsync(newOrder, cancellationToken);
        }

        return order.Id;
    }
}