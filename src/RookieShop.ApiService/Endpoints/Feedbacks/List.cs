using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Feedbacks;
using RookieShop.Application.Feedbacks.Queries.List;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Feedbacks;

public sealed class List(ISender sender) : IEndpoint<Ok<ListFeedbackResponse>, ListFeedbackRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapGet("/feedbacks",
                async (
                        int pageIndex = 1,
                        int pageSize = 0,
                        string? orderBy = null,
                        bool isDescending = false,
                        ProductId? productId = null,
                        CustomerId? customerId = null) =>
                    await HandleAsync(new(pageIndex, pageSize, orderBy, isDescending, productId, customerId)))
            .Produces<Ok<ListFeedbackResponse>>()
            .WithTags(nameof(Feedbacks))
            .WithName("List Feedbacks")
            .MapToApiVersion(new(1, 0))
            .RequirePerIpRateLimit();

    public async Task<Ok<ListFeedbackResponse>> HandleAsync(ListFeedbackRequest request,
        CancellationToken cancellationToken = default)
    {
        ListFeedbackQuery query = new(
            request.PageIndex,
            request.PageSize,
            request.OrderBy,
            request.IsDescending,
            request.ProductId,
            request.CustomerId);

        var result = await sender.Send(query, cancellationToken);

        ListFeedbackResponse response = new()
        {
            PagedInfo = result.PagedInfo,
            Feedbacks = result.Value.ToFeedbackVm()
        };

        return TypedResults.Ok(response);
    }
}