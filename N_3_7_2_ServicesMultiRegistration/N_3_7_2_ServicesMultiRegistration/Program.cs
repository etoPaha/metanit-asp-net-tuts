using N_3_7_2_ServicesMultiRegistration.Core;
using N_3_7_2_ServicesMultiRegistration.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// // 1 - Пример с разными экзеплярами (значения value разные)
// builder.Services.AddSingleton<IGenerator, ValueStorage>();
// builder.Services.AddSingleton<IReader, ValueStorage>();

// 2 - Пример получения 1 объекта при добавлении сервиса
// builder.Services.AddSingleton<ValueStorage>();
// builder.Services.AddSingleton<IGenerator>(serv => serv.GetRequiredService<ValueStorage>());
// builder.Services.AddSingleton<IReader>(serv => serv.GetRequiredService<ValueStorage>());

var valueStorage = new ValueStorage();
builder.Services.AddSingleton<IGenerator>(_ => valueStorage);
builder.Services.AddSingleton<IReader>(_ => valueStorage);

var app = builder.Build();

app.UseMiddleware<GeneratorMiddleware>();
app.UseMiddleware<ReaderMiddleware>();

app.Run();