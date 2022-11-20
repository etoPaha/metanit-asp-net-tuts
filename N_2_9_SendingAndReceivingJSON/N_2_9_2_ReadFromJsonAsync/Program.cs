var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;

    if (request.Path == "/api/user")
    {
        var message = "Некорректные данные";
        try
        {
            // пытаемся получить JSON данные
            var person = await request.ReadFromJsonAsync<Person>();
            if (person != null) // если данные сконвертированы в Person
                message = $"Name: {person.Name} Age: {person.Age}";
        }
        catch
        {
        }

        // отправляем пользователю данные
        await response.WriteAsJsonAsync(new { text = message });
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("html/index.html");
    }
});

app.Run();

// -------------

public record Person(string Name, int Age);