namespace RookieShop.Infrastructure.Endpoints.Abstractions;

public interface IEndpointWithoutRequest<TResponse> : IEndpointBase
{
    Task<TResponse> HandleAsync(CancellationToken cancellationToken = default);
}