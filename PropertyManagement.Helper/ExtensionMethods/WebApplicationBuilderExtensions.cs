using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PropertyManagement.Helper.Models;

namespace PropertyManagement.Helper.ExtensionMethods
{
    public static class WebApplicationBuilderExtensions
    {
        public static void ConfigureAppSettings(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<AppSettings>(builder.Configuration);
            builder.Services.Configure<BlobStorageSettings>(builder.Configuration.GetSection(nameof(BlobStorageSettings)));
            builder.Services.Configure<RetrySettings>(builder.Configuration.GetSection(nameof(RetrySettings)));
        }

        public static void ConfigureSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
    }
}
