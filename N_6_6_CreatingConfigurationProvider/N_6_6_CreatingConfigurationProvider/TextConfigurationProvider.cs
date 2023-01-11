namespace N_6_6_CreatingConfigurationProvider;

public class TextConfigurationProvider : ConfigurationProvider
{
    public string FilePath { get; }

    public TextConfigurationProvider(string filePath)
    {
        FilePath = filePath;
    }

    public override void Load()
    {
        // Считываем данные из файла в словарь
        
        var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        using (StreamReader textReader = new StreamReader(FilePath))
        {
            string? line;
            while ((line = textReader.ReadLine()) != null)
            {
                // Первая сторока ключ, вторая значение
                string key = line.Trim();
                string? value = textReader.ReadLine() ?? "";
                
                data.Add(key, value);
            }
        }

        Data = data;
    }
}