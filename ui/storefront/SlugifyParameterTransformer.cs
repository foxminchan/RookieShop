using System.Text.RegularExpressions;

namespace RookieShop.Storefront;

public sealed partial class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    [GeneratedRegex("([a-z])([A-Z])")]
    private static partial Regex Slug();

    public string? TransformOutbound(object? value)
    {
        if (value is null)
            return null;

        var str = value.ToString();

        return string.IsNullOrEmpty(str)
            ? null
            : Slug().Replace(str, "$1-$2").ToLowerInvariant();
    }
}