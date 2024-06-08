using Refit;
using RookieShop.Storefront.Models.Report;

namespace RookieShop.Storefront.Services;

public interface IReportService
{
    [Get("/reports/best-seller-products")]
    Task <List<BestSellerProductViewModel>> GetBestSellerProductsAsync([Query] BestSellerProductFilterParams filterParams);
}