using System.Net;
using Microsoft.AspNetCore.Http;

namespace Exception.Middleware;

public class APIExceptionHandlerMiddleware : AbstractExceptionHandlerMiddleware
{
    public APIExceptionHandlerMiddleware(RequestDelegate next) : base(next)
    {
    }

    public override (HttpStatusCode code, string message) GetResponse(System.Exception exception)
    {
        HttpStatusCode code;
        string message;
        switch (exception)
        {
            case WarningException:
                code = HttpStatusCode.BadRequest;
                message = exception.Message;
                break;
            case CriticalException:
                code = HttpStatusCode.InternalServerError;
                message = exception.Message;
                break;
            default:
                code = HttpStatusCode.InternalServerError;
                message = "Unknown error occurred";
                break;
        }
        return (code, message);
    }
}