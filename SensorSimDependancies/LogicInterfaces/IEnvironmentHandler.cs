using SensorSimDependancies.ModelInterfaces;

namespace SensorSimDependancies.LogicInterfaces;

public interface IEnvironmentHandler
{
    public void EnvUpdate();
    public string GetEnvironmentColor();
    public IEnvironment GetActiveEnvironment();
    public void SetActiveEnvironment(string environmentType);
    public IEnumerable<IEnvironmentDisplayModel> GetAvailableEnvironments();
}