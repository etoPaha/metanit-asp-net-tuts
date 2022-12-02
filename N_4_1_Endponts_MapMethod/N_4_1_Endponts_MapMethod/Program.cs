using System.Text;
using N_4_1_Endponts_MapMethod.Core;
using N_4_1_Endponts_MapMethod.Core.MapHandlers;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/", () => "Index Page");
app.Map("/about", () => "About Page");
app.Map("/contact", () => "Contact Page");

app.Map("/user", () => new Person("Paha", 32));
app.Map("/consolelog", () => Console.WriteLine("Request Path: /consolelog"));

app.Map("/simplehandler", MapHandlers.SimpleHandler);
app.Map("/userhandler", MapHandlers.UserHandler);

app.Map("/requestdelegate", async (context) =>
{
    await context.Response.WriteAsync("RequestDelegate Page");
});

app.Map("/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
{
    var endpoints = endpointSources.SelectMany(source => source.Endpoints);
    return string.Join("\n", endpoints);
});

app.Map("/routes-details", (IEnumerable<EndpointDataSource> endpointSources) =>
{
    var sb = new StringBuilder();
    var endpoints = endpointSources.SelectMany(eSrc => eSrc.Endpoints);
    foreach (var endpoint in endpoints)
    {
        sb.AppendLine(endpoint.DisplayName);

        if (endpoint is RouteEndpoint routeEndpoint)
        {
            sb.AppendLine(routeEndpoint.RoutePattern.RawText);
        }
    }

    return sb.ToString();
});

app.Run();