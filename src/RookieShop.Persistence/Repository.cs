using Ardalis.Specification.EntityFrameworkCore;
using RookieShop.Domain.SeedWork;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Persistence;

public sealed class Repository<T>(ApplicationDbContext dbContext)
    : RepositoryBase<T>(dbContext), IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot;