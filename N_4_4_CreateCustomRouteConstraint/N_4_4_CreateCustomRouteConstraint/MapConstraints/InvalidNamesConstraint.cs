namespace N_4_4_CreateCustomRouteConstraint.MapConstraints;

public class InvalidNamesConstraint : IRouteConstraint
{
    private string[] _names = { "Tom", "Sam", "Bob" };

    public bool Match(
        HttpContext? httpContext, 
        IRouter? route, 
        string routeKey, 
        RouteValueDictionary values,
        RouteDirection routeDirection)
    {
        var nameToCheck = values[routeKey]?.ToString();
        return !_names.Contains(nameToCheck);
    }
}