using SensorSimDependancies.ModelInterfaces;
using SensorSimModel;

namespace SensorSimDependancies.LogicInterfaces;

public interface IEnvironmentFactory
{
    /*public IEnvironment Create(string environmentType);*/
    public IEnvironment Create(EnvironmentType environmentType);
    public IEnumerable<IEnvironmentDisplayModel> GetRegisteredEnvironments();
}