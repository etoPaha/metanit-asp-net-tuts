namespace N_3_5_UseServicesInMiddleware.Core;

public class TimeService
{
    public string Time { get; }

    public TimeService()
    {
        Time = DateTime.Now.ToLongTimeString();
    }
}