﻿using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Models;
using RookieShop.Storefront.Services;

namespace RookieShop.Storefront.Controllers;

public class ProductController(
    ICategoryService categoryService,
    IProductService productService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var categories = await categoryService.ListCategoriesAsync();
        var products = await productService.ListProductsAsync(new());
        var model = new ProductCategoryViewModel
        {
            Products = products,
            Categories = categories
        };
        return View(model);
    }

    public async Task<IActionResult> Detail(string id)
    {
        var product = await productService.GetProductByIdAsync(new(id));
        return View(product);
    }
}