namespace DSRCourseProject.Services.Languages;

using DSRCourseProject.Services.Answers;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddAnswerService(this IServiceCollection services)
    {
        services.AddSingleton<IAnswerService, AnswerService>();

        return services;
    }
}
