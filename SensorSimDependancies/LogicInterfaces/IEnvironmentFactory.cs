using SensorSimDependancies.ModelInterfaces;

namespace SensorSimDependancies.LogicInterfaces;

public interface IEnvironmentFactory
{
    public void CreateEnvironment();
    public IEnumerable<IEnvironmentDisplayModel> GetAvailableEnvironments();
}