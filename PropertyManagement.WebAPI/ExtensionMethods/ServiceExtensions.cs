using PropertyManagement.Helper.LogService;
using PropertyManagement.WebAPI.Services;


namespace PropertyManagement.WebAPI.ExtensionMethods
{
    public static class ServiceExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IStorageService, BlobStorageService>();

            services.AddTransient(typeof(ILoggerService<>), typeof(LoggerService<>));
        }
    }
}
