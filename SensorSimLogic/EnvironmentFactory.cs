using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;
using SensorSimModel.Environment;

namespace SensorSimLogic;

public class EnvironmentFactory : IEnvironmentFactory
{
    private readonly Dictionary<string, Func<IEnvironment>> _environments;

    public EnvironmentFactory()
    {
        _environments = new()
        {
            {"Ocean", () => new Ocean()}
        };
    }
    
    public void CreateEnvironment()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IEnvironmentDisplayModel> GetAvailableEnvironments()
    {
        return _environments.Keys.Select(key => new EnvironmentDisplayModel
        {
            Name = key,
        });
    }
}