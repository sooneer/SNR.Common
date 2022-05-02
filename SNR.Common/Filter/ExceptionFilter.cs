namespace SNR.Common;

public class ExceptionFilter : IExceptionFilter
{
    //public readonly ILogger<ExceptionFilter> _logger;

    public ExceptionFilter()
    {
    }

    public void OnException(ExceptionContext context)
    {
        //var cont = context;
        var error = new ExceptionFilterModel();

        if (context.Exception is NotificationException)
        {
            error.Status = (int)HttpStatusCode.NotAcceptable;

            error.Data = context.Exception.Message;
        }
        else if (context.Exception is AuthenticationException)
        {
            error.Status = (int)HttpStatusCode.Forbidden;
            error.Data = context.Exception.Message;
        }
        else if (context.Exception is AuthorizationException)
        {
            error.Status = (int)HttpStatusCode.Unauthorized;
            error.Data = context.Exception.Message;
        }
        else
        {
            error.Status = (int)HttpStatusCode.InternalServerError;
            error.Data = "Sistemsel bir hata oluştu.";
            try
            {
                var logMessage = string.Format("{0} - {1} --> {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm"), context.HttpContext.Request.Path, JsonConvert.SerializeObject(context.Exception));
                TextFileHelper.Write(logMessage);
            }
            catch (Exception)
            {
            }
        }

        // _logger.LogError(Strings.Log.EventId.General, context.Exception.Message);

        // context.HttpContext.Response.Clear();
        // context.HttpContext.Response.StatusCode = error.Status;
        // context.HttpContext.Response.ContentType = "application/json";
        // context.HttpContext.Response.WriteAsync(error.ToString());
        // context.HttpContext.Response.Body = new StringContent(error.ToString());
        // context.Result = new BadRequestResult();

        context.Result = new ContentResult()
        {
            Content = error.ToString(),
            ContentType = "application/json",
            StatusCode = error.Status
        };
    }
}