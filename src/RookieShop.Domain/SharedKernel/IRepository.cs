using Ardalis.Specification;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.SharedKernel;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot;