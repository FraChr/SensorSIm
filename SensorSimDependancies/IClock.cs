using System.Diagnostics;

namespace SensorSimDependancies;

public interface IClock
{
    public TimeSpan GetElapsedTime();
    public Stopwatch StartStopwatch();
    public void StopStopwatch();
}