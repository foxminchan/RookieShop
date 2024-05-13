using Ardalis.SmartEnum;

namespace RookieShop.Domain.Entities.OrderAggregator.Enums;

public sealed class PaymentMethod : SmartEnum<PaymentMethod>
{
    public static readonly PaymentMethod Cash = new(nameof(Cash), 1);
    public static readonly PaymentMethod Card = new(nameof(Card), 2);

    private PaymentMethod(string name, int id) : base(name, id)
    {
    }
}