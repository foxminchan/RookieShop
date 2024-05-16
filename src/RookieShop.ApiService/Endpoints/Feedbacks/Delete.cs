using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.Application.Feedbacks.Command.Delete;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Feedbacks;

public sealed class Delete(ISender sender) : IEndpoint<NoContent, DeleteFeedbackRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapDelete("/feedbacks/{id}", async (FeedbackId id) => await HandleAsync(new(id)))
            .Produces<NoContent>(StatusCodes.Status204NoContent)
            .WithTags(nameof(Feedbacks))
            .WithName("Delete Feedback")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<NoContent> HandleAsync(DeleteFeedbackRequest request,
        CancellationToken cancellationToken = default)
    {
        DeleteFeedbackCommand command = new(request.Id);

        await sender.Send(command, cancellationToken);

        return TypedResults.NoContent();
    }
}