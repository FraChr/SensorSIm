using SensorSimDependancies.ModelInterfaces;

namespace SensorSimDependancies.LogicInterfaces;

public interface ISensor
{
    ISensorDisplayModel ToDisplayModel();
    void UpdateFromEnvironment(IEnvironment environment);
}