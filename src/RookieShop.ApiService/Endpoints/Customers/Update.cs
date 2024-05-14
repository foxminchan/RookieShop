using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using RookieShop.ApiService.ViewModels.Customers;
using RookieShop.Application.Customers.Commands.Update;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Customers;

public sealed class Update(ISender sender) : IEndpoint<Ok<CustomerVm>, UpdateCustomerRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPut("/customers", async (UpdateCustomerRequest request) => await HandleAsync(request))
            .Produces<Ok<CustomerVm>>()
            .WithTags(nameof(Customers))
            .WithName("Update Customer")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<Ok<CustomerVm>> HandleAsync(UpdateCustomerRequest request,
        CancellationToken cancellationToken = default)
    {
        UpdateCustomerCommand command = new(
            request.Id,
            request.Name,
            request.Email,
            request.Phone,
            request.Gender,
            request.AccountId);

        var result = await sender.Send(command, cancellationToken);

        return TypedResults.Ok(result.Value.ToCustomerVm());
    }
}