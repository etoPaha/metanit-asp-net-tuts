using N_3_6_ScopedServicesInSingletonObjects.Core;
using MyTimer = N_3_6_ScopedServicesInSingletonObjects.Core.Timer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITimer, MyTimer>();
builder.Services.AddSingleton<TimeService>();

var app = builder.Build();

// app.UseMiddleware<CtorTimerMiddleware>();
app.UseMiddleware<InvokeTimerMiddleware>();

app.Run();