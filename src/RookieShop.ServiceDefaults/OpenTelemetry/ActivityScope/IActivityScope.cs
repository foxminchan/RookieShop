﻿using System.Diagnostics;

namespace RookieShop.ServiceDefaults.OpenTelemetry.ActivityScope;

public interface IActivityScope
{
    Activity? Start(string name) =>
        Start(name, new());

    Activity? Start(string name, StartActivityOptions options);

    Task Run(
        string name,
        Func<Activity?, CancellationToken, Task> run,
        CancellationToken ct
    ) => Run(name, run, new(), ct);

    Task Run(
        string name,
        Func<Activity?, CancellationToken, Task> run,
        StartActivityOptions options,
        CancellationToken ct
    );

    Task<TResult> Run<TResult>(
        string name,
        Func<Activity?, CancellationToken, Task<TResult>> run,
        CancellationToken ct
    ) => Run(name, run, new(), ct);

    Task<TResult> Run<TResult>(
        string name,
        Func<Activity?, CancellationToken, Task<TResult>> run,
        StartActivityOptions options,
        CancellationToken ct
    );
}