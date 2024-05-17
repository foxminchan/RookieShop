using RookieShop.Domain.Entities.OrderAggregator;

namespace RookieShop.Application.Orders.DTOs;

public static class DomainToDtoMapper
{
    public static OrderDto ToOrderDto(this Order order)
    {
        var orderDetails = order.OrderDetails.ToOrderItemDto();

        return new(
            order.Id,
            order.PaymentMethod,
            order.Card?.Last4Digits,
            order.Card?.BrandName,
            order.Card?.ChargeId,
            order.ShippingAddress?.Street,
            order.ShippingAddress?.City,
            order.ShippingAddress?.Province,
            order.TotalPrice(),
            order.CustomerId,
            order.OrderStatus,
            orderDetails);
    }

    public static IEnumerable<OrderDto> ToOrderDto(this IEnumerable<Order> orders) =>
        orders.Select(x => x.ToOrderDto());

    public static OrderItemDto ToOrderItemDto(this OrderDetail orderDetail) =>
        new(orderDetail.ProductId, orderDetail.Quantity, orderDetail.Price);

    public static IEnumerable<OrderItemDto> ToOrderItemDto(this IEnumerable<OrderDetail> orderDetails) =>
        orderDetails.Select(x => x.ToOrderItemDto());
}