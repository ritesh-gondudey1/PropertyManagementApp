namespace PropertyManagement.Helper.Models
{
    public class AppSettings
    {
        public const string OptionsName = nameof(AppSettings);

        public string[]? ClientUris { get; set; }
        public BlobStorageSettings? BlobStorageSettings { get; set; }
        public RetrySettings? RetrySettings { get; set; }
    }

    public class BlobStorageSettings
    {
        public const string OptionsName = nameof(BlobStorageSettings);
        public string? Uri { get; set; }
        public string? ContainerName { get; set; }
        public string? BlobName { get; set; }
        public string? SASToken { get; set; }
    }

    public class RetrySettings
    {
        public const string OptionsName = nameof(RetrySettings);
        public int? MaxRetryCount { get; set; }
        public int? RetryAttempt { get; set; }
    }
}
