using Ardalis.SmartEnum;

namespace RookieShop.Domain.Entities.CustomerAggregator.Enums;

public sealed class Gender : SmartEnum<Gender>
{
    public static readonly Gender Male = new(nameof(Male), 1);
    public static readonly Gender Female = new(nameof(Female), 2);
    public static readonly Gender Other = new(nameof(Other), 3);

    private Gender(string name, int id) : base(name, id)
    {
    }
}