using SensorSimDependancies.LogicInterfaces;

namespace SensorSimModel.Sensor;

public class SensorDisplayModel : ISensorDisplayModel
{
    public string Name { get; set; }
    public string Temperature { get; set; }
}