namespace SNR.Common;

public class TokenFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.Filters.Any(k => k is DisableTokenFilter))
        {
            return;
        }

        string token = context.HttpContext.Request.Headers[Strings.API.Header.Token].ToString();

        if (string.IsNullOrEmpty(token))
        {
            throw new AuthenticationException("Token kontrolü başarısız.");
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {

    }
}