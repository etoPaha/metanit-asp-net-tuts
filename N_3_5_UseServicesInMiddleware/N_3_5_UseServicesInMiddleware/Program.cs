using N_3_5_UseServicesInMiddleware.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<TimeService>();

var app = builder.Build();

app.UseMiddleware<TimerCtorServiceExampleMiddleware>();
app.UseMiddleware<TimerInvokeServiceExampleMiddleware>();

app.Run(async (context) => await context.Response.WriteAsync("Main page"));

app.Run();