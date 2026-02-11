using SensorSimDependancies;
using System.Timers;
using SensorSimDependancies.ModelInterfaces;
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
    
    public TimeSpan GetTime()
    {
        return _clock.GetElapsedTime();
    }
}