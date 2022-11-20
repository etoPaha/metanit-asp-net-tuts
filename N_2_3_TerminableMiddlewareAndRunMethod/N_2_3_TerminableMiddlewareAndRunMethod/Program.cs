using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Простой терминальный middleware
// app.Run(async (context) => await context.Response.WriteAsync("Hello terminate middleware"));

// ----------------------------

// Терминальный middleware в виде отдельного метода
// app.Run(HandleRequest);
//
// async Task HandleRequest(HttpContext context)
// {
//     await context.Response.WriteAsync("Hello terminate middleware from separate method");
// }

// ----------------------------

int x = 2;
app.Run(async (context) =>
{
    x = x * 2;
    await context.Response.WriteAsync($"Result: {x}");
});

app.Run();