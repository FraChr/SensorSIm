/*using SensorSimDependancies.ModelInterfaces;*/

using SensorSimModel;
using SensorSimModel.Interfaces;

namespace SensorSimLogic.Interfaces;

public interface IEnvironmentFactory
{
    /*public IEnvironment Create(string environmentType);*/
    public IEnvironment Create(EnvironmentType environmentType);
    public IEnumerable<IEnvironmentDisplayModel> GetRegisteredEnvironments();
}