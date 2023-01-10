// 1. Меняем launchSettings.json
// Добавляем в профиль "commandLineArgs"

// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();
//
// app.MapGet("/", (IConfiguration appConfig) => $"{appConfig["name"]} - {appConfig["age"]}");
//
// app.Run();

// --------------------------------------------------------------------------------------------------------------------

// 2. Запуск проекта из коммандной строки
// Открываем папку с проектом
// Выполняем команду параметрами - dotnet run name=Tom age=40

// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();
//
// app.MapGet("/", (IConfiguration appConfig) => $"{appConfig["name"]} - {appConfig["age"]}");
//
// app.Run();

// 3. Программная симуляция аргументов командной строки

// string[] commandLineArgs = {"name=Alice", "age=29"};
// var builder = WebApplication.CreateBuilder(commandLineArgs);
// var app = builder.Build();
//
// app.Map("/", (IConfiguration appConf) => $"{appConf["name"]} - {appConf["age"]}");
//
// app.Run();

// 4. Применение метода AddCommandLine()

// var builder = WebApplication.CreateBuilder();
//
// string[] commandLineArgs = { "name=Sam", "age=25" };
// builder.Configuration.AddCommandLine(commandLineArgs);
//
// var app = builder.Build();
//
// app.Map("/", (IConfiguration appConf) => $"{appConf["name"]} - {appConf["age"]}");
//
// app.Run();

// 5. Переменные среды окружения как источник конфигурации

// var builder = WebApplication.CreateBuilder();
// var app = builder.Build();
//
// app.Map("/", (IConfiguration appConf) => $"OneDrive: {appConf["OneDrive"] ?? "not set"}");
//
// app.Run();

// 6. Хранение конфигурации в памяти

var builder = WebApplication.CreateBuilder();

builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
{
    { "name", "Tom" },
    { "age", "37" }
});

var app = builder.Build();


app.Map("/", (IConfiguration appConf) =>
{
    var name = appConf["name"];
    var age = appConf["age"];

    return $"{name} - {age}";
});
