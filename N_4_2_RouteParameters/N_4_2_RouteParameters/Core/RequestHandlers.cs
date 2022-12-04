namespace N_4_2_RouteParameters.Core;

public static class RequestHandlers
{
    public static string HandleRequest(string id, string firstName, string lastName)
    {
        return $"User Id: {id}; First name: {firstName}; Last name: {lastName};";
    }
}