using Refit;

namespace RookieShop.Storefront.Models.Report;

public sealed class BestSellerProductFilterParams
{
    [AliasAs("top")] public int Top { get; set; } = 4;
}