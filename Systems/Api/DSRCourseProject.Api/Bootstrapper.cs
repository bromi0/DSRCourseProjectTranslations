namespace DSRCourseProject.Api;

using DSRCourseProject.Api.Settings;
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
            /*
            .AddTagService()
            .AddUserAccountService()
            .AddCache()
            .AddRabbitMq()
            .AddActions()
            .AddAuthorService()*/
            ;

        return services;
    }
}
