/*using SensorSimDependancies.ModelInterfaces;*/

using SensorSimModel;
using SensorSimModel.Interfaces;

namespace SensorSimLogic.Interfaces;

public interface IEnvironmentFactory
{
    /*public IEnvironment Create(string environmentType);*/
    public IEnvironment Create(EnvironmentTypes environmentTypes);
    public IEnumerable<IEnvironmentDisplayModel> GetRegisteredEnvironments();
}