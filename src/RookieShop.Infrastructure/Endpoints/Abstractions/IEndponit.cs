namespace RookieShop.Infrastructure.Endpoints.Abstractions;

public interface IEndpoint<TResponse, in TRequest> : IEndpointBase
{
    Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
}