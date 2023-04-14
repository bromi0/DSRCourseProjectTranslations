namespace DSRCourseProject.Api;

using DSRCourseProject.Services.Settings;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services
            .AddMainSettings()
            .AddSwaggerSettings()
            .AddIdentitySettings()
            /*.AddApiSpecialSettings()
            .AddBookService()
            .AddUserAccountService()
            .AddCache()
            .AddRabbitMq()
            .AddActions()
            .AddAuthorService()*/
            ;

        return services;
    }
}
