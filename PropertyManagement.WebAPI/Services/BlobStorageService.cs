using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PropertyManagement.Helper.Models;
using PropertyManagement.Services.Services;

namespace PropertyManagement.WebAPI.Services
{
    public class BlobStorageService : IStorageService
    {
        private readonly IStorageDataService _storageDataService;
        private readonly AppSettings _appSettings;

        public BlobStorageService(IStorageDataService storageDataService, IOptions<AppSettings> appSettingOptions)
        {
            _storageDataService = storageDataService;
            _appSettings = appSettingOptions?.Value ?? throw new ArgumentNullException(nameof(appSettingOptions));
        }

        public async Task<IEnumerable<PropertyModel>?> GetPropertiesAsync(string containerName, string blobName)
        {
            try
            {
                var jsonResult = await _storageDataService.GetAsync(_appSettings);
                if (jsonResult == null)
                {
                    return null;
                }
                var result = JsonConvert.DeserializeObject<List<PropertyModel>>(jsonResult);
                if (result == null)
                {
                    return null;
                }

                return result;
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
