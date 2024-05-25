using RookieShop.Application.Orders.DTOs;

namespace RookieShop.ApiService.ViewModels.Orders;

public static class DtoToViewModelMapper
{
    public static OrderVm ToOrderVm(this OrderDto order)
    {
        var orderItems = order.OrderItems.ToOrderItem();

        return new(
            order.Id,
            order.PaymentMethod,
            order.Last4,
            order.Brand,
            order.ChargeId,
            order.Street,
            order.City,
            order.Province,
            order.TotalPrice,
            order.CustomerId,
            order.OrderStatus,
            order.CreatedDate,
            orderItems);
    }

    public static List<OrderVm> ToOrderVm(this IEnumerable<OrderDto> orders) =>
        orders.Select(ToOrderVm).ToList();

    public static OrderItemVm ToOrderItem(this OrderItemDto orderItem) =>
        new(orderItem.Id, orderItem.Quantity, orderItem.Price);

    public static List<OrderItemVm> ToOrderItem(this IEnumerable<OrderItemDto> orderItems) =>
        orderItems.Select(ToOrderItem).ToList();
}