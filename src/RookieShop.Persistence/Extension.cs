using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RookieShop.Domain.SharedKernel;
using RookieShop.Persistence.Interceptors;

namespace RookieShop.Persistence;

public static class Extension
{
    public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IDatabaseFactory, DatabaseFactory>();

        builder.AddNpgsqlDbContext<ApplicationDbContext>("shopdb",
            configureDbContextOptions: dbContextOptionsBuilder =>
            {
                dbContextOptionsBuilder.UseNpgsql(optionsBuilder =>
                    {
                        optionsBuilder.MigrationsAssembly(AssemblyReference.DbContextAssembly.FullName);
                        optionsBuilder.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30), null);
                    })
                    .UseExceptionProcessor()
                    .UseSnakeCaseNamingConvention()
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                dbContextOptionsBuilder.AddInterceptors(new AuditableEntityInterceptor());

                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development)
                    dbContextOptionsBuilder
                        .LogTo(Console.WriteLine, LogLevel.Information)
                        .EnableDetailedErrors()
                        .EnableSensitiveDataLogging();
            });

        builder.Services.AddScoped<IDatabaseFacade>(p => p.GetRequiredService<ApplicationDbContext>());
        builder.Services.AddScoped<IDomainEventContext>(p => p.GetRequiredService<ApplicationDbContext>());
        builder.Services.AddScoped(typeof(IReadRepository<>), typeof(Repository<>));
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return builder;
    }
}