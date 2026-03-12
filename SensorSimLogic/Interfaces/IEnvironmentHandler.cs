using SensorSimModel;
using SensorSimModel.Interfaces;

namespace SensorSimLogic.Interfaces;

public interface IEnvironmentHandler
{
    public void EnvUpdate();
    public string GetEnvironmentColor();
    public IEnvironment GetActiveEnvironment();
    public void SetActiveEnvironment(EnvironmentTypes environmentTypes);
    public IEnumerable<IEnvironmentDisplayModel> GetAvailableEnvironments();
}