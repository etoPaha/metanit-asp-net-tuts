using N_3_7_2_ServicesMultiRegistration.Core;

namespace N_3_7_2_ServicesMultiRegistration.Middlewares;

public class ReaderMiddleware
{
    private IReader _reader;

    public ReaderMiddleware(RequestDelegate _, IReader reader) => _reader = reader;

    public async Task InvokeAsync(HttpContext context)
    {
        await context.Response.WriteAsync($"Current value: {_reader.ReadValue()}");
    }
}