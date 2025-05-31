using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PropertyManagement.Helper.Models;
using PropertyManagement.WebAPI.Services;

namespace PropertyManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/properties")]
    public class PropertyApiController : ControllerBase
    {
        private readonly IStorageService _blobStorageService;
        private readonly AppSettings _appSettings;

        public PropertyApiController(IStorageService storageService, IOptions<AppSettings> appSettingOptions)
        {
            _blobStorageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
            _appSettings = appSettingOptions?.Value ?? throw new ArgumentNullException(nameof(appSettingOptions));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            ArgumentNullException.ThrowIfNull(_appSettings?.BlobStorageSettings?.ContainerName, nameof(_appSettings.BlobStorageSettings.ContainerName));
            ArgumentNullException.ThrowIfNull(_appSettings?.BlobStorageSettings?.BlobName, nameof(_appSettings.BlobStorageSettings.BlobName));
            var result = await _blobStorageService.GetPropertiesAsync(_appSettings.BlobStorageSettings.ContainerName,
                _appSettings.BlobStorageSettings.BlobName);

            if (result?.Any() == false)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
