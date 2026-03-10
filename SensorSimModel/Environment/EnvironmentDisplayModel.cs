using SensorSimModel.Interfaces;

namespace SensorSimModel.Environment;

public class EnvironmentDisplayModel : IEnvironmentDisplayModel
{
    public EnvironmentType Type { get; set; }
    public string Name { get; set; }
}