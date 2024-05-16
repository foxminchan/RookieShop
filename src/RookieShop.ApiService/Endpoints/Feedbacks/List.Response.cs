using Ardalis.Result;
using RookieShop.ApiService.ViewModels.Feedbacks;

namespace RookieShop.ApiService.Endpoints.Feedbacks;

public sealed class ListFeedbackResponse
{
    public PagedInfo? PagedInfo { get; set; }
    public List<FeedbackVm>? Feedbacks { get; set; } = [];
}