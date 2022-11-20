using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Routing.Matching;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Get request headers
// app.Run(async (context) =>
// {
//     var stringBuilder = new StringBuilder();
//     stringBuilder.Append("<table>");
//
//     foreach (var header in context.Request.Headers)
//     {
//         stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
//     }
//
//     stringBuilder.Append("</table>");
//
//     context.Response.ContentType = "text/html; charset=utf-8";
//     await context.Response.WriteAsync(stringBuilder.ToString());
// });

// ---------------------------------------------------

// app.Run(async (context) =>
// {
//     var acceptHeaderValue = context.Request.Headers.Accept;
//     var contentTypeHeaderValue = context.Request.Headers.ContentType;
//
//     var sb = new StringBuilder();
//     sb.Append($"Accept: {acceptHeaderValue}");
//     sb.Append($"ContentType: {contentTypeHeaderValue}");
//     
//     await context.Response.WriteAsync(sb.ToString());
// });

// ---------------------------------------------------

// app.Run(async (context) =>
// {
//     var acceptHeaderValue = context.Request.Headers["Accept"];
//
//     await context.Response.WriteAsync($"Accept: {acceptHeaderValue}");
// });

// --------------------------------------------------

// app.Run(async (context) =>
// {
//     var path = context.Request.Path;
//     
//     await context.Response.WriteAsync($"Path: {path}");
// });

// --------------------------------------------------

// app.Run(async (context) =>
// {
//     var path = context.Request.Path;
//     var response = context.Response;
//     var now = DateTime.Now;
//
//     if (path == "/date")
//     {
//         await response.WriteAsync($"current date: {now.ToShortDateString()}");
//     }
//     else if (path == "/time")
//     {
//         await response.WriteAsync($"current time: {now.ToShortTimeString()}");
//     }
//     else
//     {
//         await response.WriteAsync("Hello, dear friend!");
//     }
//     
// });

// --------------------------------------------------

// QueryString - строка запроса
// app.Run(async (context) =>
// {
//     context.Response.ContentType = "text/html; charset=utf-8";
//
//     var stringBuilder = new StringBuilder();
//     stringBuilder.Append($"<p>Path: {context.Request.Path}</p>");
//     stringBuilder.Append($"<p>QueryString: {context.Request.QueryString}</p>");
//
//     await context.Response.WriteAsync(stringBuilder.ToString());
// });

// --------------------------------------------------

// Query - Dictionary of url params
// app.Run(async (context) =>
// {
//     var stringBuilder = new StringBuilder();
//     stringBuilder.Append("<h3>Параметры строки запроса</h3>");
//     
//     stringBuilder.Append("<table>");
//     stringBuilder.Append("<tr><td>Параметр</td><td>Значение</td></tr>");
//     
//     foreach (var param in context.Request.Query)
//     {
//         stringBuilder.Append($"<tr><td>{param.Key}</td><td>{param.Value}</td></tr>");
//     }
//     
//     stringBuilder.Append("</table>");
//
//     context.Response.ContentType = "text/html; charset=utf-8";
//     await context.Response.WriteAsync(stringBuilder.ToString());
// });

// --------------------------------------------------

app.Run(async (context) =>
{
    string name = context.Request.Query["name"];
    string age = context.Request.Query["age"];

    await context.Response.WriteAsync($"{name} - {age}");
});

app.Run();