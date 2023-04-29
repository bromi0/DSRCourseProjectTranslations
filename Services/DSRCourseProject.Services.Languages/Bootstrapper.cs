namespace DSRCourseProject.Services.Languages;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddLanguageService(this IServiceCollection services)
    {
        services.AddSingleton<ILanguageService, LanguageService>();

        return services;
    }
}
