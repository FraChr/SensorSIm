using SensorSimDependancies.ModelInterfaces;
using SensorSimModel;

namespace SensorSimDependancies.LogicInterfaces;

public interface IEnvironmentHandler
{
    public void EnvUpdate();
    public string GetEnvironmentColor();
    public IEnvironment GetActiveEnvironment();
    /*public void SetActiveEnvironment(string environmentType);*/
    public void SetActiveEnvironment(EnvironmentType environmentType);
    public IEnumerable<IEnvironmentDisplayModel> GetAvailableEnvironments();
}