namespace DSRCourseProject.Api;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services
            .AddMainSettings()
            .AddSwaggerSettings()
            .AddIdentitySettings()
            .AddApiSpecialSettings()
            .AddTagService()
            .AddLanguageService()
            .AddTranslationRequestsService()
            .AddAnswerService()
            /*            
            .AddUserAccountService()
            .AddCache()
            .AddRabbitMq()
            .AddActions()
            .AddAuthorService()*/
            ;

        return services;
    }
}
