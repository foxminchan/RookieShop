using System.Text.Json;
using Ardalis.GuardClauses;
using Ardalis.Result;
using Medallion.Threading;
using Microsoft.Extensions.Logging;
using RookieShop.Application.Orders.Services;
using RookieShop.Application.Products.Services;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.OrderAggregator;
using RookieShop.Domain.Entities.OrderAggregator.Enums;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Cache.Redis;

namespace RookieShop.Application.Orders.Command.Create;

public sealed class CreateOrderHandler(
    IRedisService redisService,
    IOrderService orderPaymentService,
    IProductService productRepository,
    IRepository<Order> orderRepository,
    IReadRepository<Customer> customerRepository,
    IDistributedLockProvider distributedLockProvider,
    ILogger<CreateOrderHandler> logger) : ICommandHandler<CreateOrderCommand, Result<OrderId>>
{
    public async Task<Result<OrderId>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByIdAsync(request.AccountId, cancellationToken);
        Guard.Against.NotFound(request.AccountId, customer);

        var basket = await redisService.HashGetOrSetAsync<Basket>(
            nameof(Basket),
            request.AccountId.ToString(),
            () => null!);
        Guard.Against.NotFound(request.AccountId, basket);

        var orderDetails = basket.BasketDetails
            .Select(detail => new OrderDetail(detail.Id, detail.Quantity, detail.Price)).ToList();

        Order order;

        await using (await distributedLockProvider.TryAcquireLockAsync(request.AccountId.ToString(),
                         cancellationToken: cancellationToken))
        {
            await productRepository.StockValidationAsync(orderDetails, cancellationToken);

            var newOrder = await CreateOrder(request, customer, orderDetails, basket, cancellationToken);

            logger.LogInformation(
                "[{Command}] - Creating order for account {AccountId} with {@Order}",
                nameof(CreateOrderCommand), request.AccountId, JsonSerializer.Serialize(newOrder));

            order = await orderRepository.AddAsync(newOrder, cancellationToken);

            order.AddOrderDetail(request.AccountId, order, customer.Email);
        }

        return order.Id;
    }

    private async Task<Order> CreateOrder(CreateOrderCommand request, Customer customer, List<OrderDetail> orderDetails,
        Basket basket, CancellationToken cancellationToken)
    {
        if (request.PaymentMethod == PaymentMethod.Cash)
            return Order.Factory.Create(
                request.PaymentMethod,
                null, null, null,
                request.Street, request.City, request.Province,
                customer.Id, OrderStatus.Pending,
                orderDetails);

        var charge = await orderPaymentService.ProcessPaymentAsync(request, customer, basket, cancellationToken);

        return Order.Factory.Create(
            request.PaymentMethod,
            charge.Last4, charge.BrandName, charge.ChargeId,
            request.Street, request.City, request.Province,
            customer.Id, OrderStatus.Pending,
            orderDetails);
    }
}