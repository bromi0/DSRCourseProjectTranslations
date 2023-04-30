namespace DSRCourseProject.Context;

using DSRCourseProject.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DbSeeder
{
    private static IServiceScope ServiceScope(IServiceProvider serviceProvider) => serviceProvider.GetService<IServiceScopeFactory>()!.CreateScope();
    private static MainDbContext DbContext(IServiceProvider serviceProvider) => ServiceScope(serviceProvider).ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>().CreateDbContext();

    //private static readonly string masterUserName = "Admin";
    //private static readonly string masterUserEmail = "admin@dsrnetscool.com";
    //private static readonly string masterUserPassword = "Pass123#";

    //private static void ConfigureAdministrator(IServiceScope scope)
    //{
    //    //    var defaults = scope.ServiceProvider.GetService<IDefaultsSettings>();

    //    //    if (defaults != null)
    //    //    {
    //    //        var userService = scope.ServiceProvider.GetService<IUserService>();
    //    //        if (addAdmin && (!userService?.Any() ?? false))
    //    //        {
    //    //            var user = userService.Create(new CreateUserModel
    //    //            {
    //    //                Type = UserType.ForPortal,
    //    //                Status = UserStatus.Active,
    //    //                Name = defaults.AdministratorName,
    //    //                Password = defaults.AdministratorPassword,
    //    //                Email = defaults.AdministratorEmail,
    //    //                IsEmailConfirmed = !defaults.AdministratorEmail.IsNullOrEmpty(),
    //    //                Phone = null,
    //    //                IsPhoneConfirmed = false,
    //    //                IsChangePasswordNeeded = true
    //    //            })
    //    //                .GetAwaiter()
    //    //                .GetResult();

    //    //            userService.SetUserRoles(user.Id, Infrastructure.User.UserRole.Administrator).GetAwaiter().GetResult();
    //    //        }
    //    //    }
    //}

    public static void Execute(IServiceProvider serviceProvider, bool addDemoData, bool addAdmin = true)
    {
        using var scope = ServiceScope(serviceProvider);
        ArgumentNullException.ThrowIfNull(scope);

        //if (addAdmin)
        //{
        //    ConfigureAdministrator(scope);
        //}

        if (addDemoData)
        {
            Task.Run(async () =>
            {
                await ConfigureDemoData(serviceProvider);
            });
        }
    }

    private static async Task ConfigureDemoData(IServiceProvider serviceProvider)
    {
        await Filldata(serviceProvider);
    }

    private static async Task Filldata(IServiceProvider serviceProvider)
    {
        await using var context = DbContext(serviceProvider);

        if (context.Languages.Any() || context.Translations.Any() || context.Tags.Any())
            return;

        var l1 = new Entities.Language()
        {
            Name = "English",
        };
        context.Languages.Add(l1);

        var l2 = new Entities.Language()
        {
            Name = "Russian",
        };
        context.Languages.Add(l2);

        var l3 = new Entities.Language()
        {
            Name = "Spanish",
        };
        context.Languages.Add(l3);

        context.Tags.Add(new Entities.Tag()
        {
            Value = "science"
        });
        context.Tags.Add(new Entities.Tag()
        {
            Value = "joke"
        });
        context.Tags.Add(new Entities.Tag()
        {
            Value = "slang"
        });
        context.SaveChanges();

        context.Translations.Add(new Entities.TranslationRequest()
        {
            Content = "You can also use this strategy to maintain " +
            "multiple sets of migrations, for example, one for development " +
            "and another for release-to-release upgrades.",
            Tags = context.Tags.Where(t => t.Value.Equals("science")).ToList(),
            SourceLanguage = l1,
            TargetLanguage = l2
        });

        context.Translations.Add(new Entities.TranslationRequest()
        {
            Content = "¿Por qué los pájaros vuelan hacia el sur en invierno? Porque es demasiado lejos para caminar.",
            Tags = context.Tags.Where(t => t.Value.Equals("joke")).ToList(),
            SourceLanguage = l3,
            TargetLanguage = l2
        });

        var t3 = new Entities.TranslationRequest()
        {
            Content = "Шляпа",
            Tags = context.Tags.Where(t => t.Value.Equals("slang") || t.Value.Equals("Joke")).ToList(),
            SourceLanguage = l3,
            TargetLanguage = l1
        };
        context.Translations.Add(t3);
        var r1 = new Entities.TranslationAnswer()
        {
            Content = "Failure",
            Request = t3
        };
        context.Answers.Add(r1);
        var r2 = new Entities.TranslationAnswer()
        {
            Content = "A hat",
            Request = t3
        };
        context.Answers.Add(r2);

        context.SaveChanges();
    }
}