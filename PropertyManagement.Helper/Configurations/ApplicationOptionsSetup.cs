using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PropertyManagement.Helper.Configurations
{
    public class ApplicationOptionsSetup<T> : IConfigureOptions<T> where T : class
    {
        private readonly IConfiguration _configuration;

        public ApplicationOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Configure(T options)
        {
            _configuration.GetSection(options.GetType().Name).Bind(options);
        }
    }
}
