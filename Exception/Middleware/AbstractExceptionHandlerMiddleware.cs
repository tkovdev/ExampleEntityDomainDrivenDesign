using System.Net;
using System.Text.Json;
using Exception.Models;
using Microsoft.AspNetCore.Http;

namespace Exception.Middleware;

/// <summary>
/// Abstract handler for all exceptions.
/// </summary>
public abstract class AbstractExceptionHandlerMiddleware
{
    /// <summary>
    /// This key should be used to store the exception in the <see cref="IDictionary{TKey,TValue}"/> of the exception data,
    /// to be localized in the abstract handler.
    /// </summary>
    public static string LocalizationKey => "LocalizationKey";

    private readonly RequestDelegate _next;

    /// <summary>
    /// Gets HTTP status code response and message to be returned to the caller.
    /// Use the ".Data" property to set the key of the messages if it's localized.
    /// </summary>
    /// <param name="exception">The actual exception</param>
    /// <returns>Tuple of HTTP status code and a message</returns>
    public abstract (HttpStatusCode code, string message) GetResponse(System.Exception exception);

    public AbstractExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (System.Exception exception)
        {
            // log the error
            var response = context.Response;
            response.ContentType = "application/json";
            
            // get the response code and message
            var (status, message) = GetResponse(exception);
            response.StatusCode = (int) status;
            var resModel = new ResponseModel()
            {
                Message = message,
                Success = false
            };
            await response.WriteAsync(JsonSerializer.Serialize(resModel));
        }
    }
}