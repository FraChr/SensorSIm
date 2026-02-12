using SensorSimDependancies.LogicInterfaces;

namespace SensorSimModel.Sensor;

public class TempSensor : SensorBase, ITemperature
{
    public string Name { get; set; }
    public double Temperature { get; set; }
    public byte[] Image { get; set; }
    
    public TempSensor()
    {
        Name = "TempSensor";
        Temperature = -255;
    }
}
