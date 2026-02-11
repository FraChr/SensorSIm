using System.Diagnostics;

namespace SensorSimDependancies.ModelInterfaces;

public interface IClock
{
    public TimeSpan GetElapsedTime();
    public Stopwatch StartStopwatch();
    public void StopStopwatch();
}