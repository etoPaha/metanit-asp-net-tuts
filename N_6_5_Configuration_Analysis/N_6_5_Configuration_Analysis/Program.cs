// var builder = WebApplication.CreateBuilder();
//
// builder.Configuration.AddJsonFile("config.json");
//
// var app = builder.Build();
//
// app.Map("/", (IConfiguration appConfig) =>
// {
//     IConfigurationSection connStrings = appConfig.GetSection("ConnectionStrings");
//     string defaultConnection = connStrings.GetSection("DefaultConnection").Value;
//
//     return defaultConnection ?? "";
// });
//
// app.Map("/1", (IConfiguration appConf) =>
// {
//     string defaultConnection = appConf.GetSection("ConnectionStrings:DefaultConnection").Value;
//
//     return defaultConnection;
// });
//
// app.Map("/2", (IConfiguration appConf) =>
// {
//     string defaultConnection = appConf["ConnectionStrings:DefaultConnection"];
//
//     return defaultConnection;
// });
//
// app.Map("/3", (IConfiguration appConf) =>
// {
//     string connection = appConf.GetConnectionString("DefaultConnection");
//
//     return connection;
// });
//
// app.Run();

// ------------------------------------------------------------------------------------------
// Исследование файла конфигурации

using System.Text;

var builder = WebApplication.CreateBuilder();

builder.Configuration.AddJsonFile("project.json");

var app = builder.Build();

app.Map("/", (IConfiguration appConf) => GetSectionContent(appConf.GetSection("projectConfig")));

string GetSectionContent(IConfiguration configSection)
{
    StringBuilder contentBuilder = new();
    foreach (var section in configSection.GetChildren())
    {
        contentBuilder.Append($"\"{section.Key}\":");
        if (section.Value == null)
        {
            // Секция имеет вложения
            string subSectionContent = GetSectionContent(section);

            contentBuilder.Append($"{{\n{subSectionContent}}},\n");
        }
        else
        {
            contentBuilder.Append($"\"{section.Value}\",\n");
        }
    }

    return contentBuilder.ToString();
}

app.Run();