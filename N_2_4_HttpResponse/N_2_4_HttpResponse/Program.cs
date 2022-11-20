using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Использование Response и метода WriteAsync()
// app.Run(async (context) =>
// {
//     await context.Response.WriteAsync("Hello http response", Encoding.Default);
// });

// ----------------------------------------------

// Установка заголовков
// app.Run(async (context) =>
// {
//     var response = context.Response;
//     
//     // Добавляем заголовки
//     response.Headers.ContentLanguage = "ru-RU";
//     response.Headers.ContentType = "text/plain; charset=utf-8";
//     
//     // Добавляем кастомные заголовки
//     response.Headers.Append("secret-id", "256");
//
//     await response.WriteAsync("the response with set headers");
// });

// ----------------------------------------------

// // Set response status code
// app.Run(async (context) =>
// {
//     context.Response.StatusCode = 404;
//     await context.Response.WriteAsync("Resource Not Found");
// });

// ----------------------------------------------

app.Run(async (context) =>
{
    var response = context.Response;
    response.ContentType = "text/html; charset=utf-8";
    await response.WriteAsync("<h2>Hello HTML</h2><h3>Great to see you.</h3>");
});

app.Run();