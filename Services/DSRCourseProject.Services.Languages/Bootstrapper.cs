namespace Microsoft.Extensions.DependencyInjection;

using DSRCourseProject.Services.Languages;

public static class Bootstrapper
{
    public static IServiceCollection AddLanguageService(this IServiceCollection services)
    {
        services.AddSingleton<ILanguageService, LanguageService>();

        return services;
    }
}
