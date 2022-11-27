using N_2_15_MiddlewareClasses.Core;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseToken("555");

app.Run(async (context) => await context.Response.WriteAsync("Hello - Token is correct!"));

app.Run();