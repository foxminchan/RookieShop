using RookieShop.Domain.Entities.OrderAggregator.ValueObjects;

namespace RookieShop.UnitTests.Builders;

public sealed class ShippingAddressBuilder
{
    private ShippingAddress _shippingAddress;

    public ShippingAddressBuilder() => _shippingAddress = WithDefaultValues();

    public static string TestStreet => "364 Cong Hoa Street";
    public static string TestCity => "Tan Binh District";
    public static string TestProvince => "Ho Chi Minh City";

    public ShippingAddress Build() => _shippingAddress;

    public ShippingAddress WithDefaultValues()
    {
        _shippingAddress = ShippingAddress.Create(TestStreet, TestCity, TestProvince);
        return _shippingAddress;
    }
}