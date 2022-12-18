// -----------------------------------------------------------
// Получение данных конфигурации

// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();
//
// // Установка настроек конфигурации
// app.Configuration["name"] = "Tom";
// app.Configuration["age"] = "37";
//
// app.Run(async (context) =>
// {
//     // Получение настроек конфигурации
//     string name = app.Configuration["name"];
//     string age = app.Configuration["age"];
//
//     await context.Response.WriteAsync($"{name} - {age}");
// });
//
// app.Run();

// -----------------------------------------------------------
// Добавление источника конфигурации

// var builder = WebApplication.CreateBuilder();
//
// builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
// {
//     {"name", "Tom"},
//     {"age", "37"}
// });
//
// var app = builder.Build();
//
// app.Run(async (context) =>
// {
//     string name = app.Configuration["name"];
//     string age = app.Configuration["age"];
//
//     await context.Response.WriteAsync($"{name} = {age}");
// });
//
// app.Run();

// -----------------------------------------------------------
// Получение конфигурации через Dependancy Injection

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Configuration["name"] = "Pavel";
app.Configuration["age"] = "32";

app.Map("/", (IConfiguration appConfig) => $"{appConfig["name"]} - {appConfig["age"]}");

app.Run();