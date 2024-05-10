using Ardalis.Specification;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.SharedKernel;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot;