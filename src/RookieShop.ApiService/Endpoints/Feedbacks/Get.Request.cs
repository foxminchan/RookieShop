using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Feedbacks;

public sealed record GetFeedbackRequest(FeedbackId Id);