namespace DSRCourseProject.Api.Configuration;

using DSRCourseProject.Common;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

/// <summary>
/// Extension configuring Health checks for a project.
/// </summary>
public static class HealthCheckConfiguration
{

    public static IServiceCollection AddAppHealthChecks(this IServiceCollection services, IConfiguration c)
    {
        services.AddHealthChecks()
            .AddCheck<SelfHealthCheck>("DSRCourseProject.API");

        services.AddHealthChecks().AddSqlServer(c.GetConnectionString("MainContext") ?? "", null, "Sql Select 1");

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