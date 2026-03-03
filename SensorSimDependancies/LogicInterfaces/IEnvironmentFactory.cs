using SensorSimDependancies.ModelInterfaces;

namespace SensorSimDependancies.LogicInterfaces;

public interface IEnvironmentFactory
{
    public IEnvironment Create(string environmentType);
    public IEnumerable<IEnvironmentDisplayModel> GetAvailableEnvironments();
}