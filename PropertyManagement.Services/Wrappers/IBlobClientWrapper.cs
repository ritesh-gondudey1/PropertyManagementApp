namespace PropertyManagement.Services.Wrappers
{
    public interface IBlobClientWrapper
    {
        Task<string> GetBlobDataWithRetryAsync();
    }
}
