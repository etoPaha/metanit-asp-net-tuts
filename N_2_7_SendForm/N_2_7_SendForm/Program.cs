using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (context) =>
{
    var response = context.Response;

    response.ContentType = "text/html; charset=utf-8";
    if (context.Request.Path == "/postuser")
    {
        var form = context.Request.Form;
        string name = form["name"];
        string age = form["age"];

        var sb = new StringBuilder();
        sb.Append("<div>");
        sb.Append($"<p>Name: {name}</p>");
        sb.Append($"<p>Age: {age}</p>");
        sb.Append("</div>");
        
        await response.WriteAsync(sb.ToString());
    }
    else
    {
        await response.SendFileAsync("html/index.html");
    }
});

app.Run();