namespace N_3_5_UseServicesInMiddleware.Core;

public class TimerCtorServiceExampleMiddleware
{
    private RequestDelegate _next;
    private TimeService _timeService;

    public TimerCtorServiceExampleMiddleware(RequestDelegate next, TimeService timeService)
    {
        _next = next;
        _timeService = timeService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path == "/timeCtor")
        {
            context.Response.ContentType = "text/html; charset=utf-8";

            await context.Response.WriteAsync($"Текущее время: {_timeService.Time}");
        }
        else
        {
            await _next.Invoke(context);
        }
    }
}