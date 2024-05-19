using System.Diagnostics;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using RookieShop.IntegrationTests.Extensions;
using Testcontainers.Azurite;
using Testcontainers.PostgreSql;
using Testcontainers.Redis;

namespace RookieShop.IntegrationTests.Fixtures;

public sealed class ApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram>, IAsyncLifetime, IContextFixture where TProgram : class
{
    private readonly List<IContainer> _containers = [];
    private AzuriteContainer _storageContainer = default!;
    public WebApplicationFactory<TProgram> Instance { get; private set; } = default!;

    public Task InitializeAsync()
    {
        Debug.WriteLine($"{nameof(ApplicationFactory<TProgram>)} called {nameof(InitializeAsync)}");
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Test";
        Instance = WithWebHostBuilder(builder => builder.UseEnvironment(env));
        return Task.CompletedTask;
    }

    public new Task DisposeAsync()
    {
        Debug.WriteLine($"{nameof(ApplicationFactory<TProgram>)} called {nameof(DisposeAsync)}");
        return Task
            .WhenAll(_containers.Select(container => container.DisposeAsync().AsTask()))
            .ContinueWith(async _ => await base.DisposeAsync());
    }

    public ApplicationFactory<TProgram> WithCacheContainer()
    {
        Debug.WriteLine($"{nameof(ApplicationFactory<TProgram>)} called {nameof(WithCacheContainer)}");
        _containers.Add(new RedisBuilder()
            .WithName($"test_cache_{Guid.NewGuid()}")
            .WithImage("redis/redis-stack-server:7.2.0-v10")
            .WithCommand("redis-server --requirepass NashTech@2024")
            .WithCleanUp(true)
            .Build());

        return this;
    }

    public ApplicationFactory<TProgram> WithDbContainer()
    {
        Debug.WriteLine($"{nameof(ApplicationFactory<TProgram>)} called {nameof(WithDbContainer)}");
        _containers.Add(new PostgreSqlBuilder()
            .WithDatabase($"test_db_{Guid.NewGuid()}")
            .WithUsername("root")
            .WithPassword("NashTech@2024")
            .WithImage("postgres:16.2-alpine3.19")
            .WithCleanUp(true)
            .Build());

        return this;
    }

    public ApplicationFactory<TProgram> WithStorageContainer()
    {
        Debug.WriteLine($"{nameof(ApplicationFactory<TProgram>)} called {nameof(WithStorageContainer)}");
        _storageContainer = new AzuriteBuilder()
            .WithPortBinding(10000, true)
            .Build();

        return this;
    }

    public async Task StartContainersAsync(CancellationToken cancellationToken = default)
    {
        Debug.WriteLine($"{nameof(ApplicationFactory<TProgram>)} called {nameof(StartContainersAsync)}");

        await _storageContainer.StartWithWaitAndRetryAsync(cancellationToken: cancellationToken);

        if (_containers.Count == 0) return;

        await Task.WhenAll(_containers.Select(container =>
            container.StartWithWaitAndRetryAsync(cancellationToken: cancellationToken)));

        Instance = _containers.Aggregate(this as WebApplicationFactory<TProgram>, (current, container) =>
            current.WithWebHostBuilder(builder =>
            {
                switch (container)
                {
                    case PostgreSqlContainer dbContainer:
                        builder.UseSetting("ConnectionStrings:Postgres", dbContainer.GetConnectionString());
                        break;

                    case RedisContainer cacheContainer:
                        builder.UseSetting("Redis:Url", cacheContainer.GetConnectionString());
                        break;

                    case AzuriteContainer storageContainer:
                        builder.UseSetting("Azurite:ConnectionString", storageContainer.GetConnectionString());
                        break;
                }
            }));
    }

    public new HttpClient CreateClient() => Instance.CreateClient();

    public async Task StopContainersAsync()
    {
        Debug.WriteLine($"{nameof(ApplicationFactory<TProgram>)} called {nameof(StopContainersAsync)}");

        if (_containers.Count == 0) return;

        await Task.WhenAll(_containers.Select(container => container.DisposeAsync().AsTask()))
            .ContinueWith(async _ => await base.DisposeAsync())
            .ContinueWith(async _ => await InitializeAsync())
            .ConfigureAwait(false);

        _containers.Clear();
    }
}