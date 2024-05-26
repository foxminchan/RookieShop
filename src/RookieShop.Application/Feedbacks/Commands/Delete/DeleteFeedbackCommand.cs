using Ardalis.Result;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Feedbacks.Commands.Delete;

public sealed record DeleteFeedbackCommand(FeedbackId Id) : ICommand<Result>;