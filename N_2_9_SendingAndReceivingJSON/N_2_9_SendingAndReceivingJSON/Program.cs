var builder = WebApplication.CreateBuilder(); // Создаем билдер приложения
var app = builder.Build();

// Use WriteAsJsonAsync() method
// app.Run(async (context) =>
// {
//     Person tom = new("tom", 22);
//     await context.Response.WriteAsJsonAsync(tom);
// });

// Use WriteAsync method
app.Run(async (context) =>
{
    var response = context.Response;
    response.Headers.ContentType = "application/json; charset=utf-8";
    await response.WriteAsync("{'name':'Tom', 'age': 37}");
});

app.Run();

public record Person(string Name, int Age);