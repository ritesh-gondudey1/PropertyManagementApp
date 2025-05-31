using Microsoft.AspNetCore.Http;
using PropertyManagement.Helper.LogService;
using System.Net;

namespace PropertyManagement.Helper.Middlewares
{
    public class ExceptionMiddleware<T> where T : class
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService<ExceptionMiddleware<T>> _loggerService;

        public ExceptionMiddleware(RequestDelegate next, ILoggerService<ExceptionMiddleware<T>> loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (UnauthorizedAccessException ex)
            {
                var correlationId = Guid.NewGuid().ToString();
                _loggerService.LogError(null, ex, correlationId, typeof(T).Assembly?.GetName()?.Name);
                await HandleExceptionAsync(httpContext, ex, (int)HttpStatusCode.Unauthorized, correlationId);
            }
            catch (Azure.RequestFailedException ex)
            {
                var correlationId = Guid.NewGuid().ToString();
                string message = ex.Message;
                if (ex.Status == (int)HttpStatusCode.BadRequest || ex.Status == (int)HttpStatusCode.Forbidden)
                {
                    message = $"Looks like invalid inputs provided to azure blob request";
                }
                _loggerService.LogError(null, ex, correlationId, typeof(T).Assembly?.GetName()?.Name);
                await HandleExceptionAsync(httpContext, ex, ex.Status, correlationId, message);
            }
            catch (Exception ex)
            {
                var correlationId = Guid.NewGuid().ToString();
                _loggerService.LogError(null, ex, correlationId, typeof(T).Assembly?.GetName()?.Name);
                await HandleExceptionAsync(httpContext, ex, (int)HttpStatusCode.InternalServerError, correlationId);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, int statusCode, string correlationId, string message = null)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = message ?? $"Some thing went wrong",
                CorrelationId = correlationId
                //Message = $"Internal Server Error from the custom {typeof(T).Assembly?.GetName()?.Name} middleware with CorrelationId: {correlationId}."
            }.ToString());
        }

        public class ErrorDetails
        {
            public int StatusCode { get; internal set; }
            public string Message { get; internal set; }
            public string CorrelationId { get; internal set; }

            public override string ToString()
            {
                return System.Text.Json.JsonSerializer.Serialize(this);
            }
        }
    }
}
