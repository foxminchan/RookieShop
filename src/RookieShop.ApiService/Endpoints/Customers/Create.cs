using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RookieShop.ApiService.Filters;
using RookieShop.Application.Customers.Commands.Create;
using RookieShop.Domain.Constants;
using RookieShop.Infrastructure.Endpoints.Abstractions;
using RookieShop.Infrastructure.RateLimiter;

namespace RookieShop.ApiService.Endpoints.Customers;

public sealed class Create(ISender sender) : IEndpoint<Created<CreateCustomerResponse>, CreateCustomerRequest>
{
    public void MapEndpoint(IEndpointRouteBuilder app) =>
        app.MapPost("/customers", async (
                [FromHeader(Name = HeaderName.IdempotencyKey)]
                string key, CreateCustomerRequest request) => await HandleAsync(request))
            .AddEndpointFilter<IdempotencyFilter>()
            .Produces<Created<CreateCustomerResponse>>(StatusCodes.Status201Created)
            .Produces<BadRequest<IEnumerable<ValidationError>>>(StatusCodes.Status400BadRequest)
            .WithTags(nameof(Customers))
            .WithName("Create Customer")
            .MapToApiVersion(new(1, 0))
            .RequirePerUserRateLimit();

    public async Task<Created<CreateCustomerResponse>> HandleAsync(CreateCustomerRequest request,
        CancellationToken cancellationToken = default)
    {
        CreateCustomerCommand command = new(
            request.Name,
            request.Email,
            request.Phone,
            request.Gender,
            request.AccountId);

        var result = await sender.Send(command, cancellationToken);

        CreateCustomerResponse response = new(result.Value);

        return TypedResults.Created($"/api/customers/{result.Value}", response);
    }
}