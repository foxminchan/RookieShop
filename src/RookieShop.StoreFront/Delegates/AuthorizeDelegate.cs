using Microsoft.AspNetCore.Authentication;

namespace RookieShop.Storefront.Delegates;

public sealed class AuthorizeDelegate : DelegatingHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizeDelegate(IHttpContextAccessor httpContextAccessor) => _httpContextAccessor = httpContextAccessor;

    public AuthorizeDelegate(IHttpContextAccessor httpContextAccessor, HttpMessageHandler innerHandler) :
        base(innerHandler) => _httpContextAccessor = httpContextAccessor;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (_httpContextAccessor.HttpContext is not { } context)
            return await base.SendAsync(request, cancellationToken);

        var accessToken = await context.GetTokenAsync("access_token");

        if (accessToken is not null) request.Headers.Authorization = new("Bearer", accessToken);

        return await base.SendAsync(request, cancellationToken);
    }
}