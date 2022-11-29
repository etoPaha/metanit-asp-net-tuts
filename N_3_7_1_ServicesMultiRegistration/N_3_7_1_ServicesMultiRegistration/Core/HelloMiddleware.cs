using System.Text;

namespace N_3_7_1_ServicesMultiRegistration.Core;

public class HelloMiddleware
{
    private readonly IEnumerable<IHelloService> _helloServices;

    public HelloMiddleware(RequestDelegate _, IEnumerable<IHelloService> helloServices)
    {
        _helloServices = helloServices;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.ContentType = "text/html; charset=utf-8";

        var sbResponseText = new StringBuilder();
        foreach (var service in _helloServices)
        {
            sbResponseText.Append($"<h3>{service.Message}</h3>");
        }

        await context.Response.WriteAsync(sbResponseText.ToString());
    }
}