using Azure.Storage.Blobs;
using PropertyManagement.Helper.ExtensionMethods;

namespace PropertyManagement.Services.Wrappers
{
    public class BlobClientWrapper : IBlobClientWrapper
    {
        private readonly BlobClient _blobClient;

        public BlobClientWrapper(BlobClient blobClient)
        {
            _blobClient = blobClient;
        }

        public Task<string> GetBlobDataWithRetryAsync()
        {
            return _blobClient.GetBlobDataWithRetryAsync();
        }
    }
}
