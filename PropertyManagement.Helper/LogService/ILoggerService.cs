namespace PropertyManagement.Helper.LogService
{
    public interface ILoggerService<T>
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message, Exception ex, string correlationId, string? assemblyName);
    }
}
