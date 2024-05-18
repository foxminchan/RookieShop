using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Feedbacks;
using RookieShop.Application.Feedbacks.Queries.Get;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Feedbacks;

public sealed class Get(ISender sender) : IEndpoint<Ok<FeedbackVm>, GetFeedbackRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/feedbacks/{id}", async (FeedbackId id) => await HandleAsync(new(id)))
            .Produces<Ok<FeedbackVm>>()
            .Produces<NotFound<string>>(StatusCodes.Status404NotFound)
            .WithTags(nameof(Feedbacks))
            .WithName("Get Feedback")
            .MapToApiVersion(new(1, 0))
            .RequirePerIpRateLimit();

    public async Task<Ok<FeedbackVm>> HandleAsync(GetFeedbackRequest request,
        CancellationToken cancellationToken = default)
    {
        GetFeedbackQuery query = new(request.Id);

        var result = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(result.Value.ToFeedbackVm());
    }
}