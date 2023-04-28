namespace DSRCourseProject.Services.Tags;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddTagService(this IServiceCollection services)
    {
        services.AddSingleton<ITagService, TagService>();

        return services;
    }
}
