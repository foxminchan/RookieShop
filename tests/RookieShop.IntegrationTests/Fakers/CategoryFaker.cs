using Bogus;
using RookieShop.Domain.Entities.CategoryAggregator;

namespace RookieShop.IntegrationTests.Fakers;

public sealed class CategoryFaker : Faker<Category>
{
    public CategoryFaker()
    {
        RuleFor(c => c.Id, f => new(f.Random.Guid()));
        RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0]);
        RuleFor(c => c.Description, f => f.Lorem.Sentence());
    }
}