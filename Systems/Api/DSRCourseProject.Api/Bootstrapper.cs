namespace DSRCourseProject.Api;

using DSRCourseProject.Api.Settings;
using DSRCourseProject.Services.Languages;
using DSRCourseProject.Services.Settings;
using DSRCourseProject.Services.Tags;
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
