using SensorSimModel;

namespace SensorSimDependancies.LogicInterfaces;

public interface IEnvironmentDisplayModel
{
    public EnvironmentType Type { get; set; }
    public string Name { get; set; }
}