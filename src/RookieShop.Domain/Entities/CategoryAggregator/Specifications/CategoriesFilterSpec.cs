﻿using Ardalis.Specification;

namespace RookieShop.Domain.Entities.CategoryAggregator.Specifications;

public sealed class CategoriesFilterSpec : Specification<Category>
{
    public CategoriesFilterSpec(int pageIndex = 1, int pageSize = 0)
    {
        if (pageSize == 0) pageSize = int.MaxValue;

        Query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);
    }
}