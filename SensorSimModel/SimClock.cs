using System.Diagnostics;
using SensorSimDependancies;

namespace SensorSimModel;

public class Clock : IClock
{
    private Stopwatch Stopwatch {get; set;} = new();
    
    public Stopwatch StartStopwatch()
    {
        return Stopwatch.StartNew();
    }

    public void StopStopwatch()
    {
        Stopwatch.Stop();
    }
    
}