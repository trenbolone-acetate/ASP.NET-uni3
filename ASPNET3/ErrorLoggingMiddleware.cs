namespace ASPNET3;

public class ErrorLoggingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await using StreamWriter streamWriter = new StreamWriter("ErrorLog.txt", true);
            await streamWriter.WriteLineAsync($"{DateTime.Now} - Error: {ex.Message}");

            throw;  
        }
    }
}

public static class ErrorLoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorLoggingMiddleware>();
    }
}