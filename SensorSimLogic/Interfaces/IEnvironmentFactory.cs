using SensorSimModel;
using SensorSimModel.Interfaces;

namespace SensorSimLogic.Interfaces;

public interface IEnvironmentFactory
{
    public IEnvironment Create(EnvironmentTypes environmentTypes);
    public IEnumerable<EnvironmentTypes> GetRegisteredEnvironments();
}