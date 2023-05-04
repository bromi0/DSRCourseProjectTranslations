namespace Microsoft.Extensions.DependencyInjection;

using DSRCourseProject.Services.Answers;

public static class Bootstrapper
{
    public static IServiceCollection AddAnswerService(this IServiceCollection services)
    {
        services.AddSingleton<IAnswerService, AnswerService>();

        return services;
    }
}
