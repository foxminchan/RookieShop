using MediatR;

namespace RookieShop.Domain.SharedKernel;

public interface IQuery<out TResponse> : IRequest<TResponse>;