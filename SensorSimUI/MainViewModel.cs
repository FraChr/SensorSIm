namespace SensorSimUI;

public class MainViewModel
{
    public SensorViewModel SensorVm  { get; set; }

    public MainViewModel(SensorViewModel sensorVm)
    {
        SensorVm = sensorVm;
    }
}