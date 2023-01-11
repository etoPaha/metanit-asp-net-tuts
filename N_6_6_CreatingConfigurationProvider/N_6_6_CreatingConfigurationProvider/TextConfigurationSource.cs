namespace N_6_6_CreatingConfigurationProvider;

public class TextConfigurationSource : IConfigurationSource
{
    public string FileName { get; }

    public TextConfigurationSource(string filename)
    {
        FileName = filename;
    }

    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        // Получаем полный путь к файлу
        string filePath = builder.GetFileProvider().GetFileInfo(FileName).PhysicalPath;

        return new TextConfigurationProvider(filePath);
    }
}