using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;
using SensorSimModel.Environment;
using SensorSimModel.Environment.DesertEnvironments;
using SensorSimModel.Environment.WaterEnvironments;
using SensorSimUtility;

namespace SensorSimLogic;

public class EnvironmentFactory : IEnvironmentFactory
{
    private readonly Dictionary<string, Func<IEnvironment>>
        _environments = FactoryHelpers.CreateEnvironmentDictionary();
    
    public IEnvironment Create(string environmentType)
    {
        if(!_environments.TryGetValue(environmentType, out var environment))
            throw new ArgumentException($"Unknown environment type: {environmentType}");
        
        return environment();
    }

    public IEnumerable<IEnvironmentDisplayModel> GetRegisteredEnvironments()
    {
        return _environments.Keys.Select(key => new EnvironmentDisplayModel
        {
            Name = key,
        });
    }
}