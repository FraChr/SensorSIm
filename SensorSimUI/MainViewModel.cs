using System.Windows.Threading;

namespace SensorSimUI;

public class MainViewModel
{
    private readonly DispatcherTimer _displayTimer = new();
    public SensorViewModel SensorVm  { get; set; }
    public ClockViewModel ClockVm { get; set; }

    public MainViewModel(SensorViewModel sensorVm,  ClockViewModel clockVm)
    {
        SensorVm = sensorVm;
        ClockVm = clockVm;
    }

    
    
}