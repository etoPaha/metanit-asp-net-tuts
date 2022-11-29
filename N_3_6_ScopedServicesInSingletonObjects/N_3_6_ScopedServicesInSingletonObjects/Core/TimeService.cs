namespace N_3_6_ScopedServicesInSingletonObjects.Core;

public class TimeService
{
    private ITimer _timer;

    public TimeService(ITimer timer)
    {
        _timer = timer;
    }

    public string GetTime() => _timer.Time;
}