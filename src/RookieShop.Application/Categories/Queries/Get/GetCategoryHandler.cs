using Ardalis.GuardClauses;
using Ardalis.Result;
using RookieShop.Application.Categories.DTOs;
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Domain.Entities.CategoryAggregator.Specifications;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Categories.Queries.Get;

public sealed class GetCategoryHandler(IReadRepository<Category> repository)
    : IQueryHandler<GetCategoryQuery, Result<CategoryDto>>
{
    public async Task<Result<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        CategoryByIdSpec spec = new(request.Id);

        var category = await repository.FirstOrDefaultAsync(spec, cancellationToken);

        Guard.Against.NotFound(request.Id, category);

        return category.ToCategoryDto();
    }
}