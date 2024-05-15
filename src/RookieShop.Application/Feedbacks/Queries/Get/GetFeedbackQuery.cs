using Ardalis.Result;
using RookieShop.Application.Feedbacks.DTOs;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Feedbacks.Queries.Get;

public sealed record GetFeedbackQuery(FeedbackId Id) : IQuery<Result<FeedbackDto>>;