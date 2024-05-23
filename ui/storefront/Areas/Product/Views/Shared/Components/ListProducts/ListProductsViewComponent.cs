﻿using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Product.Services;

namespace RookieShop.Storefront.Areas.Product.Views.Shared.Components.ListProducts;

[ViewComponent]
public sealed class ListProductsViewComponent(IProductService productService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(IQueryCollection query)
    {
        var page = !query.ContainsKey("page") ? 1 : int.Parse(query["page"]!);

        var product = await productService.ListProductsAsync(new()
        {
            PageNumber = page
        });

        return View(product);
    }
}