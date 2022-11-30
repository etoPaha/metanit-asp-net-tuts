using N_3_7_2_ServicesMultiRegistration.Core;

namespace N_3_7_2_ServicesMultiRegistration.Middlewares;

public class GeneratorMiddleware
{
    private RequestDelegate _next;
    private IGenerator _generator;

    public GeneratorMiddleware(RequestDelegate next, IGenerator generator)
    {
        _next = next;
        _generator = generator;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path == "/generate")
        {
            await context.Response.WriteAsync($"New value: {_generator.GenerateValue()}");
        }
        else
        {
            await _next.Invoke(context);
        }
    }
}