using DSRCourseProject.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DSRCourseProject.Api.Configuration.HealthChecks
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly IDbContextFactory<MainDbContext> _contextFactory;
        public DatabaseHealthCheck(IDbContextFactory<MainDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                using var dbContext = _contextFactory.CreateDbContext();

                var result = await dbContext.Database.CanConnectAsync(cancellationToken);

                return result
                    ? HealthCheckResult.Healthy()
                    : HealthCheckResult.Unhealthy();
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy(ex.Message);
            }
        }
    }
}
