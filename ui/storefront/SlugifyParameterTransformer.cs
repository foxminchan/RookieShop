using System.Text.RegularExpressions;

namespace RookieShop.Storefront;

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        if (value == null) { return null; }
        var str = value.ToString();
        return string.IsNullOrEmpty(str) 
            ? null 
            : Regex.Replace(str, "([a-z])([A-Z])", "$1-$2").ToLower();
    }
}