using DSRCourseProject.Api;
using DSRCourseProject.Api.Configuration;
using DSRCourseProject.Services.Settings;
using DSRCourseProject.Settings;
using DSRCourseProjectTranslations.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.

services.AddDbContext<MainDbContext>(
       options =>
       {
           var connstring = builder.Configuration.GetConnectionString("MainContext") ?? "";
           if (connstring.Contains("port", StringComparison.OrdinalIgnoreCase))
           {
               options.UseNpgsql(connstring);
           } else
           {
            options.UseSqlServer(connstring);
           }
               
       });

// Logging

builder.AddAppLogger();

services.AddHttpContextAccessor();
services.AddAppCors();
services.AddAppHealthChecks(builder.Configuration);

services.AddAppVersioning();

// Swagger

services.AddAppControllerAndViews();
services.RegisterAppServices();

services.AddAppSwagger(Settings.Load<MainSettings>("Main"), Settings.Load<SwaggerSettings>("Swagger"));

var app = builder.Build();


// Configure the HTTP request pipeline.

// app.UseHttpsRedirection();

app.UseAppCors();
app.UseAppHealthChecks();

app.UseAppControllerAndViews();

app.UseAppSwagger();


app.Run();
