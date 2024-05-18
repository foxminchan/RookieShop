using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Feedbacks;
using RookieShop.Application.Feedbacks.Command.Update;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Feedbacks;

public sealed class Update(ISender sender) : IEndpoint<Ok<UpdateFeedbackResponse>, UpdateFeedbackRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPut("/feedbacks", async (UpdateFeedbackRequest request) => await HandleAsync(request))
            .Produces<Ok<UpdateFeedbackResponse>>()
            .Produces<NotFound<string>>(StatusCodes.Status404NotFound)
            .Produces<BadRequest<IEnumerable<ValidationError>>>(StatusCodes.Status400BadRequest)
            .WithTags(nameof(Feedbacks))
            .WithName("Update Feedback")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<Ok<UpdateFeedbackResponse>> HandleAsync(UpdateFeedbackRequest request,
        CancellationToken cancellationToken = default)
    {
        UpdateFeedbackCommand command = new(
            request.Id,
            request.ProductId,
            request.Rating,
            request.Content,
            request.CustomerId);

        var result = await sender.Send(command, cancellationToken);

        UpdateFeedbackResponse response = new(result.Value.ToFeedbackVm());

        return TypedResults.Ok(response);
    }
}