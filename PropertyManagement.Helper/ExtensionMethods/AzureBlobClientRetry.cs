using Azure.Storage.Blobs;
using Polly;

namespace PropertyManagement.Helper.ExtensionMethods
{
    public static class AzureBlobClientRetry
    {
        public static async Task<string> GetBlobDataWithRetryAsync(this BlobClient blobClient)
        {
            string blobData = null;
            var _retryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (exception, timeSpan, retryCount, context) =>
                    {
                        Console.WriteLine($"Retry {retryCount} due to {exception.Message}");
                    });

            // Use Polly Retry Policy
            await _retryPolicy.ExecuteAsync(async () =>
            {
                var response = await blobClient.DownloadAsync();
                using (var streamReader = new StreamReader(response.Value.Content))
                {
                    blobData = await streamReader.ReadToEndAsync();
                }
            });
            return blobData;
        }
    }
}
