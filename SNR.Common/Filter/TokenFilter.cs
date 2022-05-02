namespace SNR.Common;

public class TokenFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var path = context.HttpContext.Request.Path;
        if (path != @"/Login/Token")
        {
            string token = context.HttpContext.Request.Headers[Strings.API.Header.Token].ToString();

            if (string.IsNullOrEmpty(token))
            {
                throw new AuthenticationException("Token kontrolü başarısız.");
            }
        }

        // Do something before the action executes.
        // MyDebug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Do something after the action executes.
        // MyDebug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
    }
}