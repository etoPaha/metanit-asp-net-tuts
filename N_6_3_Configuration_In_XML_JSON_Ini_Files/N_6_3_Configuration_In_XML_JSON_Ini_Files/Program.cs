// 1. Конфигурация в JSON
//
// JsonConfigurationProvider - провайдер для работы с JSON файлами
// AddJsonFile() - метод расширения для загрузки конфигурации из JSON файла

// var builder = WebApplication.CreateBuilder();
//
// builder.Configuration.AddJsonFile("config.json");
//
// var app = builder.Build();
//
// app.Map("/", (IConfiguration appConf) => $"{appConf["person"]} - {appConf["company"]}");
//
// app.Run();

// 1.2 - Можно использовать одного файла с настройками

// var builder = WebApplication.CreateBuilder();
//
// builder.Configuration
//     .AddJsonFile("config.json")
//     .AddJsonFile("otherconfig.json"); // Во втором файле более сложная структура
//
// var app = builder.Build();
//
// app.Map("/", (IConfiguration appConf) =>
// {
//     var personName = appConf["person:profile:name"];
//     var companyName = appConf["company:name"];
//
//     return $"{personName} - {companyName}";
// });
//
// app.Run();

// 2 Конфигурация в XML

// XMLConfigurationProvider - Провайдер для использования XML файлов в конфигурации
// AddXmlFile() - метод расширения для загрузки XML файла конфигурации

// var builder = WebApplication.CreateBuilder();
//
// builder.Configuration.AddXmlFile("config.xml");
//
// var app = builder.Build();
//
// app.Map("/" , (IConfiguration appConf) => $"{appConf["person"]} - {appConf["company"]}");
//
// app.Run();

// 2.2 Несколько файлов в конфигурации (плюс сложная структура)

// var builder = WebApplication.CreateBuilder();
//
// builder.Configuration
//             .AddXmlFile("config.xml")
//             .AddXmlFile("otherconfig.xml");
//             
// var app = builder.Build();
//
// app.Map("/", (IConfiguration appConf) =>
// {
//     var personName = appConf["person:profile:name"];
//     var companyName = appConf["company:name"];
//
//     return $"{personName} - {companyName}";
// });
//
// app.Run();

// 3. Конифиурация в ini-файлах

// IniConfigurationProvider - Провайдер для получения конфигурации из INI файлов
// AddIniFile() - метод расширения для загрузки конфигрурации из ini-файла

var builder = WebApplication.CreateBuilder();

builder.Configuration.AddIniFile("config.ini");

var app = builder.Build();

app.Map("/", (IConfiguration appConf) => $"{appConf["person"]} - {appConf["company"]}");

app.Run();