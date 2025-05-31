using PropertyManagement.Helper.Models;

namespace PropertyManagement.WebAPI.Services
{
    public interface IStorageService
    {
        Task<IEnumerable<PropertyModel>?> GetPropertiesAsync(string containerName, string blobName);
    }
}
