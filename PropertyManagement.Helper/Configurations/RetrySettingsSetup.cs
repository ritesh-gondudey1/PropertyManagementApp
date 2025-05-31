using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PropertyManagement.Helper.Models;

namespace PropertyManagement.Helper.Configurations
{
    public class RetrySettingsSetup : IConfigureOptions<RetrySettings>
    {
        private readonly IConfiguration _configuration;
        private readonly string _sectionName = nameof(RetrySettings);

        public RetrySettingsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(RetrySettings options)
        {
            _configuration.GetSection(_sectionName).Bind(options);
        }
    }
}

