using N_6_6_CreatingConfigurationProvider;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddTextFile("config.txt");

var app = builder.Build();

app.Map("/", (IConfiguration appConf) => $"{appConf["name"]} - {appConf["age"]}");

app.Run();