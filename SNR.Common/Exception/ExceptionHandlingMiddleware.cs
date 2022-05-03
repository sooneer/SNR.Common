namespace SNR.Common;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
        //_logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var response = context.Response;

        var errorResponse = new ExceptionHandling_Model
        {
            Success = false,
            Message = exception.Message,
        };

        switch (exception)
        {
            case NotificationException:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;

            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorResponse.Message = "Internal Server errors. Check Logs!";
                break;
        }

        var result = errorResponse.ToString();
        await context.Response.WriteAsync(result);
    }
}