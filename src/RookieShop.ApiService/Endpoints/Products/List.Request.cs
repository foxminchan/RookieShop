﻿using RookieShop.Domain.Entities.CategoryAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Products;

public sealed record ListProductsRequest(
    int PageIndex,
    int PageSize,
    string? OrderBy = null,
    bool IsDescending = false,
    string? Search = null,
    CategoryId?[]? CategoryIds = null);