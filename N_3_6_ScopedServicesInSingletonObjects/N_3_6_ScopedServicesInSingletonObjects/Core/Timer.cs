namespace N_3_6_ScopedServicesInSingletonObjects.Core;

public class Timer : ITimer
{
    public string Time { get; }

    public Timer()
    {
        Time = DateTime.Now.ToLongTimeString();
    }
}