WebApplicationOptions options = new() { Args = args };
WebApplicationBuilder builder = WebApplication.CreateBuilder(options);
WebApplication app = builder.Build();

app.MapGet("/", () => "Hello World");

// Обычный запуск
// app.Run();

// Ассинхронный запуск с завешением
await app.StartAsync();
await Task.Delay(1000);
await app.StartAsync();