var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Пример с ошибкой
// app.Map("/users/{id}", (int id) => $"User id: {id}");
// app.Map("/", () => "Index page");

// Пример с ограничением :int
// app.Map("/users/{id:int}", (int id) => $"User id: {id}");
// app.Map("/", () => "Index page");

// Применение несколький ограничений 
app.Map("/users/{name:alpha:minlength(2)}/{age:int:range(1, 120)}", (string name, int age) => $"User age: {age}\nUser name: {name}");
app.Map("/phonebook/{phone:regex(^7-\\d{{3}}-\\d{{3}}-\\d{{4}}$)}", (string phone) => $"Phone: {phone}");
app.Map("/", () => $"Index page");

app.Run();