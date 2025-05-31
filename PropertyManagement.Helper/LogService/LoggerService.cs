using Microsoft.Extensions.Logging;

namespace PropertyManagement.Helper.LogService
{
    public class LoggerService<T> : ILoggerService<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerService(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        public void LogError(string message, Exception ex, string correlationId, string? assemblyName)
        {
            var className = ex.TargetSite?.DeclaringType?.DeclaringType?.FullName ?? "Unknown Class";
            var methodName = GetActualMethodName(ex);
            _logger.LogError(ex, message ?? $"Error: {ex.Message} in Method: {methodName}() of Class: {className}");
        }

        private string GetActualMethodName(Exception ex)
        {
            var stackTrace = ex.StackTrace;
            if (stackTrace != null)
            {
                var lines = stackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (var line in lines)
                {
                    if (!line.Contains("MoveNext"))
                    {
                        var methodName = line.Substring(line.IndexOf("at ") + 3);
                        methodName = methodName.Substring(0, methodName.IndexOf('('));
                        return methodName;
                    }
                }
            }
            return "Unknown Method";
        }
    }
}
