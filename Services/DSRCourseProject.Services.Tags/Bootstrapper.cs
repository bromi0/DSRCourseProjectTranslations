namespace Microsoft.Extensions.DependencyInjection;

using DSRCourseProject.Services.Tags;

public static class Bootstrapper
{
    public static IServiceCollection AddTagService(this IServiceCollection services)
    {
        services.AddSingleton<ITagService, TagService>();

        return services;
    }
}
