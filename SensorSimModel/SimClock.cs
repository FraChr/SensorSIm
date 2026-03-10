using System.Diagnostics;
using SensorSimModel.Interfaces;

namespace SensorSimModel;

public class SimClock : IClock
{
    private Stopwatch Stopwatch {get; set;} = new();
    
    public TimeSpan GetElapsedTime()
    {
        return Stopwatch.Elapsed;
    }
    public Stopwatch StartStopwatch()
    {
        Stopwatch.Start();
        return Stopwatch;
    }

    public void StopStopwatch()
    {
        Stopwatch.Stop();
    }
    
}