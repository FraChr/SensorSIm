using System.Windows.Threading;

namespace SensorSimUI;

public static class HelpersUi
{
    public static DispatcherTimer SetupTick(TimeSpan interval, EventHandler handler)
    {
        DispatcherTimer tickTimer = new()
        {
            Interval = interval
        };
        tickTimer.Tick += handler;
        return tickTimer;
    }
}