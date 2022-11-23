var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (context) =>
{
    if (context.Request.Path == "/old")
    {
        context.Response.Redirect("/new");
    }
    else if (context.Request.Path == "/new")
    {
        await context.Response.WriteAsync("New page");
    }
    else if (context.Request.Path == "/google")
    {
        context.Response.Redirect("https://www.google.com/search?q=metanit.com");
    }
    else
    {
        await context.Response.WriteAsync("Main page");
    }
});

app.Run();