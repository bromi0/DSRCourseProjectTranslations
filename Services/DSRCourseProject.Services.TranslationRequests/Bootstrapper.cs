namespace Microsoft.Extensions.DependencyInjection;

using DSRCourseProject.Services.Languages;
using DSRCourseProject.Services.TranslationRequests;

public static class Bootstrapper
{
    public static IServiceCollection AddTranslationRequestsService(this IServiceCollection services)
    {
        services.AddSingleton<ITranslationRequestService, TranslationRequestService>();

        return services;
    }
}
