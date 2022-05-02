using System.Diagnostics;

namespace SNR.Common;

public class PerformanceTrackerAttribute : IActionFilter
{
    private Stopwatch watch = new Stopwatch();

    public void OnActionExecuting(ActionExecutingContext context)
    {
        watch.Start();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        watch.Stop();
        var totalTime = watch.ElapsedMilliseconds;
        if (totalTime >= 2000)
        {
            // Debug.WriteLine(context.HttpContext.Request.Path + " adresinin çalışması uzun sürdü.");

#if !DEBUG
            try
            {
                EventLog.WriteEntry(Strings.General.App.Name, context.HttpContext.Request.Path + " adresinin çalışması uzun sürdü.", EventLogEntryType.Warning);
            }
            catch (Exception)
            {
            }
#endif
        }
    }
}