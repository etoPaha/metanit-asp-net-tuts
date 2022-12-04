using Microsoft.AspNetCore.Mvc;
using N_4_2_RouteParameters.Core;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.Map("/users/{id}", (string id) => $"User Id: {id}");
// app.Map("/users/{id}/{name}", (string id, string name) => $"User Id: {id}; User name: {name}");
// app.Map("/users/{age}-{name}", (string age, string name) => $"Age: {age}; Name: {name}");
//
// // Вынесение в отдельный метод
// app.Map("/users/{id}/{firstName}/{lastName}", RequestHandlers.HandleRequest);
//
// app.Map("/users", () => "Users Page");
//
// // Необязательный параметр маршрута
// app.Map("/branches/{id?}", (string? id) => $"User Id: {id??"Undefined"}");

// app.Map("/", () => "Index Page");

// ------------------------------------------------------
// Заполнение параметров по умолчанию

// app.Map("{controller=Home}/{action=Index}/{id?}", (string controller, string action, string? id) => $"Controller: {controller} \nAction: {action} \nId: {id}");

// ------------------------------------------------------
// Передача произвольного количества параметров в запросе

app.Map("/users/{**info}", (string info) => $"User info: {info}");

app.Map("/", () => "Index page");

app.Run();