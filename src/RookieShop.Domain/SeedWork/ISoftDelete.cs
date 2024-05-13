namespace RookieShop.Domain.SeedWork;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
}