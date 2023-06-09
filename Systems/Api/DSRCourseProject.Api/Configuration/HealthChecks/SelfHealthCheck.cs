﻿namespace DSRCourseProject.Api.Configuration;

using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection;

/// <summary>
/// Example health check for solution
/// </summary>
public class SelfHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var assembly = Assembly.Load("DSRCourseProject.API");
        var versionNumber = assembly.GetName().Version;

        return Task.FromResult(HealthCheckResult.Healthy(description: $"Build {versionNumber}"));
    }
}