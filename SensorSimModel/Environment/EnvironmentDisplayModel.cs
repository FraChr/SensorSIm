using SensorSimModel.Interfaces;

namespace SensorSimModel.Environment;

public class EnvironmentDisplayModel : IEnvironmentDisplayModel
{
    public EnvironmentTypes Types { get; set; }
    public string Name { get; set; }
}