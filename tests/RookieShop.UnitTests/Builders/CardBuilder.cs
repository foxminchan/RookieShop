using RookieShop.Domain.Entities.OrderAggregator.ValueObjects;

namespace RookieShop.UnitTests.Builders;

public sealed class CardBuilder
{
    private Card _card;

    public CardBuilder() => _card = WithDefaultValues();

    public static string TestBrandName => "Visa";
    public static string TestLast4Digits => "xxxx";
    public static string TestChargeId => "some-charge-id";

    public Card Build() => _card;

    public Card WithDefaultValues()
    {
        _card = Card.Create(TestBrandName, TestLast4Digits, TestChargeId);
        return _card;
    }
}