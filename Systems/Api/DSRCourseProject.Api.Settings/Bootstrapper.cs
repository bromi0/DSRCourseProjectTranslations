namespace Microsoft.Extensions.DependencyInjection;

using DSRCourseProject.Api.Settings;
using DSRCourseProject.Settings;
using Microsoft.Extensions.Configuration;

public static class Bootstrapper
{
    public static IServiceCollection AddApiSpecialSettings(this IServiceCollection services, IConfiguration? configuration = null)
    {
        var settings = Settings.Load<ApiSpecialSettings>("ApiSpecial", configuration);
        services.AddSingleton(settings);

        return services;
    }
}