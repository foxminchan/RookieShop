using RookieShop.Domain.Entities.OrderAggregator;

namespace RookieShop.UnitTests.Builders;

public class OrderDetailBuilder
{
    private OrderDetail _orderDetail;

    public OrderDetailBuilder() => _orderDetail = WithDefaultValues();

    public OrderDetail Build() => _orderDetail;

    public OrderDetail WithDefaultValues()
    {
        _orderDetail = new(new(Guid.NewGuid()), 1, 100);
        return _orderDetail;
    }
}