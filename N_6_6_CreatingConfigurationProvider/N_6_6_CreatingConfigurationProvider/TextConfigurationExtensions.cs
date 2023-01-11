namespace N_6_6_CreatingConfigurationProvider;

public static class TextConfigurationExtensions
{
    public static IConfigurationBuilder AddTextFile(this IConfigurationBuilder builder, string fileName)
    {
        if (builder == null)
            throw new ArgumentNullException(nameof(builder));

        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentException("Путь к файлу не указан");

        var source = new TextConfigurationSource(fileName);
        builder.Add(source);

        return builder;
    }
}