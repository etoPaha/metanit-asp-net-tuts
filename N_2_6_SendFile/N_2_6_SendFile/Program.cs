using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Send image
// app.Run(async (context) => await context.Response.SendFileAsync(@"img\sexy toast.gif"));

// Send html
// app.Run(async (context) =>
// {
//     context.Response.ContentType = "text/html; charset=utf-8";
//     await context.Response.SendFileAsync("html/index.html");
// });

// Html files mini middleware
// app.Run(async (context) =>
// {
//     var path = context.Request.Path;
//     var fullPath = $"html/{path}";
//     var response = context.Response;
//
//     response.ContentType = "text/html; charset=utf-8";
//     if (File.Exists(fullPath))
//     {
//         await response.SendFileAsync(fullPath);
//     }
//     else
//     {
//         response.StatusCode = 404;
//         await response.WriteAsync("<h2>Not found</h2>");
//     }
// });

// Send a file as a attachment
// app.Run(async (context) =>
// {
//     var response = context.Response;
//     var filePath = @"img\sexy toast.gif";
//
//     response.Headers.ContentDisposition = $"attachment; filename={filePath}";
//     await response.SendFileAsync(filePath);
// });

// Use IFileinfo
app.Run(async (context) =>
{
    var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
    var fileInfo = fileProvider.GetFileInfo("img/sexy toast.gif");

    await context.Response.SendFileAsync(fileInfo);
});

app.Run();