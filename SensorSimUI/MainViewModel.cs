using SensorSimUI.ViewModels;

namespace SensorSimUI;

public class MainViewModel(
    SensorViewModel sensorVm,
    ClockViewModel clockVm,
    EnvironmentViewModel envVm,
    SensorReadingsViewModel sensorReadingsVm)
{
    public SensorViewModel SensorVm  { get; set; } = sensorVm;
    public ClockViewModel ClockVm { get; set; } = clockVm;
    public EnvironmentViewModel EnvironmentVm { get; set; } = envVm;
    public SensorReadingsViewModel SensorReadingsVm { get; set; } = sensorReadingsVm;
}