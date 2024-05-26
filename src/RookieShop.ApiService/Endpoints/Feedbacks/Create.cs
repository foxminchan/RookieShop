using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RookieShop.ApiService.Filters;
using RookieShop.Application.Feedbacks.Commands.Create;
using RookieShop.Domain.Constants;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Feedbacks;

public sealed class Create(ISender sender) : IEndpoint<Created<CreateFeedbackResponse>, CreateFeedbackRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPost("/feedbacks",
                async (
                    [FromHeader(Name = HeaderName.IdempotencyKey)]
                    string key,
                    CreateFeedbackRequest request) => await HandleAsync(request))
            .AddEndpointFilter<IdempotencyFilter>()
            .Produces<Created<CreateFeedbackResponse>>(StatusCodes.Status201Created)
            .Produces<BadRequest<IEnumerable<ValidationError>>>(StatusCodes.Status400BadRequest)
            .WithTags(nameof(Feedbacks))
            .WithName("Create Feedback")
            .MapToApiVersion(new(1, 0))
            .RequirePerIpRateLimit();

    public async Task<Created<CreateFeedbackResponse>> HandleAsync(CreateFeedbackRequest request,
        CancellationToken cancellationToken = default)
    {
        CreateFeedbackCommand command = new(
            request.ProductId,
            request.Rating,
            request.Content,
            request.CustomerId);

        var result = await sender.Send(command, cancellationToken);

        CreateFeedbackResponse response = new(result.Value);

        return TypedResults.Created($"/api/feedbacks/{result.Value}", response);
    }
}