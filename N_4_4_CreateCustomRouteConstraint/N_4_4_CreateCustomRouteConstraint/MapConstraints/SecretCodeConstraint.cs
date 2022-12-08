﻿namespace N_4_4_CreateCustomRouteConstraint.MapConstraints;

public class SecretCodeConstraint : IRouteConstraint
{
    private string _secretCode;

    public SecretCodeConstraint(string secretCode)
    {
        _secretCode = secretCode;
    }
    
    public bool Match(
        HttpContext? httpContext, 
        IRouter? route, 
        string routeKey, 
        RouteValueDictionary values,
        RouteDirection routeDirection)
    {
        return values[routeKey]?.ToString() == _secretCode;
    }
}