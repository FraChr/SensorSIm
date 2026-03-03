using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;
using SensorSimModel.Environment;
using SensorSimModel.Environment.DesertEnvironments;
using SensorSimModel.Environment.WaterEnvironments;

namespace SensorSimLogic;

public class EnvironmentFactory : IEnvironmentFactory
{
    private readonly Dictionary<string, Func<IEnvironment>> _environments;

    public EnvironmentFactory()
    {
        _environments = new()
        {
            {"Ocean", () => new Ocean()},
            {"Lake", () => new Lake()},
            {"SandDesert", () => new SandDesert()}
        };
    }
    
    public IEnvironment Create(string environmentType)
    {
        if(!_environments.TryGetValue(environmentType, out var environment))
            throw new ArgumentException($"Unknown environment type: {environmentType}");
        
        return environment();
        
    }

    public IEnumerable<IEnvironmentDisplayModel> GetAvailableEnvironments()
    {
        return _environments.Keys.Select(key => new EnvironmentDisplayModel
        {
            Name = key,
        });
    }
}