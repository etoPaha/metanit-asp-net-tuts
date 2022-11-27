using System.Text.RegularExpressions;
using N_2_11_SimpleWebApi.Core;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    var response = context.Response;
    var request = context.Request;
    var path = request.Path;

    if (path == "/api/users" && request.Method == "GET")
    {
        await AppRepository.GetAllPeople(response);
    }
    else if (IsGuid(path) && request.Method == "GET")
    {
        string? id = path.Value?.Split("/")[3];
        await AppRepository.GetPerson(id, response);
    }
    else if (path == "/api/users" && request.Method == "POST")
    {
        await AppRepository.CreatPerson(response, request);
    }
    else if (path == "/api/users" && request.Method == "PUT")
    {
        await AppRepository.UpdatePerson(response, request);
    }
    else if (IsGuid(path) && request.Method == "DELETE")
    {
        string? id = path.Value?.Split("/")[3];
        await AppRepository.DeletePerson(id, response);
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("html/index.html");
    }
});

app.Run();

bool IsGuid(string guid)
{
    string expressionForGuid = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";
    
    return Regex.IsMatch(guid, expressionForGuid);
}