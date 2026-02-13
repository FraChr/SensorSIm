using SensorSimDependancies.LogicInterfaces;

namespace SensorSimModel.Sensor;

public class TempSensor : SensorBase, ITemperature
{
    public string Name { get; set; } = "TempSensor";
    public double Temperature { get; set; } = -255;
    public byte[] Image { get; set; }
}
