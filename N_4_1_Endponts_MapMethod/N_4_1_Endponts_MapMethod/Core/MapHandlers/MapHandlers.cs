namespace N_4_1_Endponts_MapMethod.Core.MapHandlers;

public class MapHandlers
{
    public static string SimpleHandler()
    {
        return "SimpleHandler Page";
    }

    public static Person UserHandler()
    {
        return new Person("Max", 5);
    }
}