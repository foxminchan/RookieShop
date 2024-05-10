using MediatR;

namespace RookieShop.Domain.SharedKernel;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>;