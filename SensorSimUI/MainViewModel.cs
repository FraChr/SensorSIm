using SensorSimUI.ViewModels;

namespace SensorSimUI;

public class MainViewModel(SensorViewModel sensorVm, ClockViewModel clockVm, EnvironmentViewModel envVm)
{
    public SensorViewModel SensorVm  { get; set; } = sensorVm;
    public ClockViewModel ClockVm { get; set; } = clockVm;
    public EnvironmentViewModel EnvironmentVm { get; set; } = envVm;
}