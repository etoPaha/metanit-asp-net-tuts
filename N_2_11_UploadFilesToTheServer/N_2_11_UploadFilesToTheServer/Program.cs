var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Добавляем мидлвар
app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;

    response.ContentType = "text/html; charset=utf-8";

    if (request.Path == "/upload" && request.Method == "POST")
    {
        IFormFileCollection files = request.Form.Files;

        if (files.Count == 0)
            await response.WriteAsync("Не файлов для сохранения");
        
        // путь к папке, где будут храниться файлы
        var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";
        
        // создаем папку для хранения файлов
        Directory.CreateDirectory(uploadPath);
        
        foreach (var file in files)
        {
            // полниый путь сохранения
            string fullPath = $"{uploadPath}/{file.FileName}";

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }

        await response.WriteAsync("Файлы успешно загружены");
    }
    else
    {
        await response.SendFileAsync("html/index.html");
    }
});

app.Run();