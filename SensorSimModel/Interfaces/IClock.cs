using System.Diagnostics;

namespace SensorSimModel.Interfaces;

public interface IClock
{
    public TimeSpan GetElapsedTime();
    public Stopwatch StartStopwatch();
    public void StopStopwatch();
}