using Microsoft.AspNetCore.Routing;

namespace RookieShop.Infrastructure.Endpoints.Abstractions;

public interface IEndpointBase
{
    void MapEndpoint(IEndpointRouteBuilder app);
}