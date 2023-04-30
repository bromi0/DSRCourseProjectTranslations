namespace DSRCourseProject.Api.Configuration;

using DSRCourseProject.Api.Configuration.HealthChecks;
using DSRCourseProject.Common;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

/// <summary>
/// Extension configuring Health checks for a project.
/// </summary>
public static class HealthCheckConfiguration
{

    public static IServiceCollection AddAppHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck<SelfHealthCheck>("DSRCourseProject.API")
            .AddCheck<DatabaseHealthCheck>("DSRCourseProject.Database");

        return services;
    }

    public static void UseAppHealthChecks(this WebApplication app)
    {
        app.MapHealthChecks("/health");

        app.MapHealthChecks("/health/detail", new HealthCheckOptions
        {
            ResponseWriter = HealthCheckHelper.WriteHealthCheckResponse,
            AllowCachingResponses = false,
        });
    }
}