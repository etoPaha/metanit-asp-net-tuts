var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Используем middleware страницы приветствия
app.UseWelcomePage();

app.Run();