namespace N_3_5_UseServicesInMiddleware.Core;

public class TimerInvokeServiceExampleMiddleware
{
    private RequestDelegate _next;

    public TimerInvokeServiceExampleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, TimeService timeService)
    {
        if (context.Request.Path == "/timeInvoke")
        {
            context.Response.ContentType = "text/html; charset=utf-8";

            await context.Response.WriteAsync($"Текущее время: {timeService?.Time}");
        }
        else
        {
            await _next.Invoke(context);
        }
    }
}