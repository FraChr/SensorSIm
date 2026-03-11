using SensorSimModel.Interfaces;

namespace SensorSimLogic;

public class ActiveSensor(ISensor sensor, ISensorDisplayModel display)
{
    public ISensor Sensor {get; set;} = sensor;
    public ISensorDisplayModel Display { get; set; } = display;
}