using Azure.Storage.Blobs;
using PropertyManagement.Helper.Models;
using PropertyManagement.Services.Wrappers;

namespace PropertyManagement.Services.Services
{
    public class AzureBlobStorageService : IStorageDataService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public AzureBlobStorageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> GetAsync(AppSettings appSettings)
        {
            ArgumentNullException.ThrowIfNull(appSettings?.BlobStorageSettings?.ContainerName, nameof(appSettings.BlobStorageSettings.ContainerName));
            ArgumentNullException.ThrowIfNull(appSettings?.BlobStorageSettings?.BlobName, nameof(appSettings.BlobStorageSettings.BlobName));

            var containerClient = _blobServiceClient.GetBlobContainerClient(appSettings.BlobStorageSettings.ContainerName);
            var blobClient = containerClient.GetBlobClient(appSettings.BlobStorageSettings.BlobName);
            var blobClientWrapper = new BlobClientWrapper(blobClient);
            return await blobClientWrapper.GetBlobDataWithRetryAsync();
        }
    }
}
