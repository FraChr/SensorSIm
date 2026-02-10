using SensorSimDependancies;
using System.Timers;
using SensorSimModel;
using Timer = System.Threading.Timer;

namespace SensorSimLogic;

public class SimTime
{
    private readonly IClock _clock = new SimClock();

    public SimTime()
    {
        _clock.StartStopwatch();
    }
    
    public TimeSpan hh()
    {
        return _clock.GetElapsedTime();
    }
}