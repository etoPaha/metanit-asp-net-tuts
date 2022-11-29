namespace N_3_6_ScopedServicesInSingletonObjects.Core;

public class CtorTimerMiddleware
{
    private TimeService _timeService;

    public CtorTimerMiddleware(RequestDelegate next, TimeService timeService)
    {
        _timeService = timeService;
    }

    public async Task Invoke(HttpContext context)
    {
        await context.Response.WriteAsync($"Time: {_timeService.GetTime()}");
    }
}