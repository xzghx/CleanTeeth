using CleanTeeth.Application.Exceptions;
using System.Net;

namespace CleanTeeth.Api.Middlewares;

public class ErrorHAndlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHAndlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptions(context, ex);
        }

    }

    private Task HandleExceptions(HttpContext context, Exception exception)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var result = string.Empty;
        switch (exception)
        {
            case NotFoundException:
                statusCode = HttpStatusCode.NotFound;
                break;

            case CustomValidationException:
                statusCode = HttpStatusCode.BadRequest;
                break;
        }

        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(result);
    }
}


public static class ErrorHandlingMiddlewareExtensions
{

    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHAndlingMiddleware>();

    }

}
