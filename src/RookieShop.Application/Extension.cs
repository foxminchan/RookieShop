using System.Diagnostics;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieShop.Infrastructure.Logging;
using RookieShop.Infrastructure.Validator;
using RookieShop.Persistence;

namespace RookieShop.Application;

public static class Extension
{
    [DebuggerStepThrough]
    public static IHostApplicationBuilder AddApplication(this IHostApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssemblies([AssemblyReference.Executing]);
        builder.Services.AddHttpContextAccessor()
            .AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(AssemblyReference.Executing,
                    Persistence.AssemblyReference.Executing);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>),
                    ServiceLifetime.Scoped);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>),
                    ServiceLifetime.Scoped);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(TxBehavior<,>),
                    ServiceLifetime.Scoped);
            });

        return builder;
    }
}