using PropertyManagement.Helper.Models;

namespace PropertyManagement.Services.Services
{
    public interface IStorageDataService
    {
        Task<string> GetAsync(AppSettings appSettings);
    }
}
