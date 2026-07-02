using System.Net;
using System.Text.Json;

namespace ProjectHubApi.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var traceId = context.TraceIdentifier;

        _logger.LogError(exception,
            "Unhandled exception occurred. TraceId: {TraceId}",
            traceId);

        var (statusCode, message) = MapException(exception);

        var response = new ApiErrorResponse
        {
            StatusCode = statusCode,
            Message = message,
            Details = exception.Message,
            TraceId = traceId
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var json = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(json);
    }

    private (int StatusCode, string Message) MapException(Exception exception)
    {
        return exception switch
        {
            ArgumentNullException => ((int)HttpStatusCode.BadRequest, "Required value was missing"),
            ArgumentException => ((int)HttpStatusCode.BadRequest, "Invalid argument"),
            KeyNotFoundException => ((int)HttpStatusCode.NotFound, "Resource not found"),
            UnauthorizedAccessException => ((int)HttpStatusCode.Unauthorized, "Unauthorized access"),
            _ => ((int)HttpStatusCode.InternalServerError, "Internal server error")
        };
    }
}