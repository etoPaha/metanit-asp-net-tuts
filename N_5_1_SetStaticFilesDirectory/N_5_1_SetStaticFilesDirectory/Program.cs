// Простой вариант где wwwroot папка для статических файлов
// var builder = WebApplication.CreateBuilder(args);

// Пример изменения папки для статических файлов
var options = new WebApplicationOptions
{
    WebRootPath = "static"
};
var builder = WebApplication.CreateBuilder(options);

var app = builder.Build();

app.UseStaticFiles(); // добавляем поддержку статических файлов

app.Run(async (context) => await context.Response.WriteAsync("Hello world"));

app.Run();