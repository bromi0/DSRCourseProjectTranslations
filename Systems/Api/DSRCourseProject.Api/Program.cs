using DSRCourseProject.Api;
using DSRCourseProject.Api.Configuration;
using DSRCourseProject.Services.Settings;
using DSRCourseProject.Settings;
using DSRCourseProject.Context;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Logging

builder.AddAppLogger();

services.AddHttpContextAccessor();
services.AddAppCors();

services.AddAppDbContext(builder.Configuration);


services.AddAppHealthChecks(builder.Configuration);
services.AddAppVersioning();

// Swagger
services.AddAppSwagger(Settings.Load<MainSettings>("Main"), Settings.Load<SwaggerSettings>("Swagger"));
services.AddAppAutoMappers();


services.AddAppControllerAndViews();
services.RegisterAppServices();




var app = builder.Build();


// Configure the HTTP request pipeline.

// app.UseHttpsRedirection();

app.UseAppCors();
app.UseAppHealthChecks();

app.UseAppControllerAndViews();

app.UseAppSwagger();

DbInitializer.Execute(app.Services);
DbSeeder.Execute(app.Services, true, true);


app.Run();
