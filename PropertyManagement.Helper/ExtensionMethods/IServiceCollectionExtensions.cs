using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PropertyManagement.Helper.Constant;
using PropertyManagement.Helper.Models;

namespace PropertyManagement.Helper.ExtensionMethods
{
    public static class IServiceCollectionExtensions
    {
        public static T GetAppSettings<T>(this IServiceCollection services) where T : class
        {
            var serviceProvider = services.BuildServiceProvider();
            var appSettings = serviceProvider.GetRequiredService<IOptions<T>>().Value;
            return appSettings;
        }

        public static void AddCors(this IServiceCollection services, AppSettings appSettings)
        {
            ArgumentNullException.ThrowIfNull(appSettings.ClientUris, nameof(appSettings.ClientUris));
            services.AddCors(options =>
            {
                options.AddPolicy(ConstantParms.PropertyManagementCors,
                    policy => policy.WithOrigins(appSettings.ClientUris)
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
            });
        }
    }
}
