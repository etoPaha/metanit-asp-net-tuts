namespace N_3_6_ScopedServicesInSingletonObjects.Core;

public class InvokeTimerMiddleware
{
    public InvokeTimerMiddleware(RequestDelegate next)
    {
        
    }

    public async Task Invoke(HttpContext context, TimeService timeService)
    {
        await context.Response.WriteAsync($"Time: {timeService.GetTime()}");
    }
}