using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";

    if (context.Request.Path == "/postuser")
    {
        var form = context.Request.Form;

        string name = form["name"];
        string age = form["age"];
        string[] languages = form["languages"];

        var langStr = String.Join(", ", languages); 

        var sbResponse = new StringBuilder();
        sbResponse.Append("<div>");
        sbResponse.Append($"<p>Name: {name}</p>");
        sbResponse.Append($"<p>Age: {age}</p>");
        sbResponse.Append($"<p>Languages: {langStr}</p>");
        sbResponse.Append("</div>");

        await context.Response.WriteAsync(sbResponse.ToString());
    }
    else if (context.Request.Path == "/multiselect")
    {
        await context.Response.SendFileAsync("html/multiselect.html");
    }
    else
    {
        await context.Response.SendFileAsync("html/index.html");
    }
});

app.Run();