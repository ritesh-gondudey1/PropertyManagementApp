using Azure;
using Azure.Storage.Blobs;
using Microsoft.Extensions.DependencyInjection;
using PropertyManagement.Helper.Models;
using PropertyManagement.Services.Services;

namespace PropertyManagement.Services.ExtensionMethods
{
    public static class IServiceCollectionExtensions
    {
        public static void AddAzureBlobStorageServices(this IServiceCollection services, AppSettings appSettings)
        {
            ArgumentNullException.ThrowIfNull(appSettings?.BlobStorageSettings?.Uri, nameof(appSettings.BlobStorageSettings.Uri));
            ArgumentNullException.ThrowIfNull(appSettings?.BlobStorageSettings?.SASToken, nameof(appSettings.BlobStorageSettings.SASToken));

            var blobServiceClient = new BlobServiceClient(new Uri(appSettings.BlobStorageSettings.Uri), new AzureSasCredential(appSettings.BlobStorageSettings.SASToken));

            services.AddSingleton(blobServiceClient);

            services.AddTransient<IStorageDataService, AzureBlobStorageService>();
        }
    }
}
