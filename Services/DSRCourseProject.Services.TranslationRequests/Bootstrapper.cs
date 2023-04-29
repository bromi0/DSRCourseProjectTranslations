namespace DSRCourseProject.Services.Languages;

using DSRCourseProject.Services.TranslationRequests;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddTranslationRequestsService(this IServiceCollection services)
    {
        services.AddSingleton<ITranslationRequestService, TranslationRequestService>();

        return services;
    }
}
