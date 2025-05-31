using PropertyManagement.Helper.Constant;
using PropertyManagement.Helper.ExtensionMethods;
using PropertyManagement.Helper.Middlewares;
using PropertyManagement.Helper.Models;
using PropertyManagement.Services.ExtensionMethods;
using PropertyManagement.WebAPI.ExtensionMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureAppSettings();

var appSettings = builder.Services.GetAppSettings<AppSettings>();

builder.Services.AddAzureBlobStorageServices(appSettings);

builder.Services.RegisterServices();

builder.ConfigureSwagger();

builder.Services.AddCors(appSettings);

var app = builder.Build();

app.UseDevelopmentSettngs();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(ConstantParms.PropertyManagementCors);

app.UseMiddleware<ExceptionMiddleware<Program>>();


app.Run();
