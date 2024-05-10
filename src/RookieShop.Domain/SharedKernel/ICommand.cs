using MediatR;

namespace RookieShop.Domain.SharedKernel;

public interface ICommand<out TResponse> : IRequest<TResponse>, ITxRequest;