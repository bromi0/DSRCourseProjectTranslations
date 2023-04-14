namespace DSRCourseProject.Api.Configuration;

using DSRCourseProject.Common;

public static class ControllerAndViewsConfiguration
{
	public static IServiceCollection AddAppControllerAndViews(this IServiceCollection services)
	{
		services
			.AddRazorPages();

		services
			.AddControllers()
			.AddNewtonsoftJson(options => options.SerializerSettings.SetDefaultSettings())
			;

		return services;
	}

	public static WebApplication UseAppControllerAndViews(this WebApplication app)
	{
		app.UseStaticFiles();

		app.MapRazorPages();
		app.MapControllers();

		return app;
	}
}