using SensorSimDependancies.ModelInterfaces;

namespace SensorSimDependancies.LogicInterfaces;

public interface IEnvironmentHandler
{
    public void Update();
    public string GetEnvironmentColor();
    public IEnvironment GetActiveEnvironment();
    public void SetActiveEnvironment(string environmentType);
    public IEnumerable<IEnvironmentDisplayModel> GetAvailableEnvironments();
}