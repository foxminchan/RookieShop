using System.Net;
using Polly;
using Polly.Retry;

namespace RookieShop.Storefront.Delegates;

public sealed class RetryDelegate : DelegatingHandler
{
    private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy
        = Policy<HttpResponseMessage>
            .HandleResult(response => response.StatusCode == HttpStatusCode.InternalServerError)
            .RetryAsync(2);

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var result =
            await _retryPolicy.ExecuteAndCaptureAsync(async () => await base.SendAsync(request, cancellationToken));

        if (result.Outcome == OutcomeType.Failure)
            throw new HttpRequestException("Failed to send request", result.FinalException);

        return result.Result;
    }
}