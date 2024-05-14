using FluentValidation;

namespace RookieShop.Application.Products.Queries.GetBySemanticRelevance;

public sealed class GetBySemanticRelevanceValidator : AbstractValidator<GetBySemanticRelevanceQuery>
{
    public GetBySemanticRelevanceValidator()
    {
        RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Text).NotEmpty();
    }
}