using SensorSimLogic.Interfaces;
using SensorSimModel;
using SensorSimModel.Environment;
using SensorSimModel.Environment.DesertEnvironments;
using SensorSimModel.Environment.WaterEnvironments;
using SensorSimModel.Interfaces;
using SensorSimUtility;

namespace SensorSimLogic;

public class EnvironmentFactory : IEnvironmentFactory
{
    /*private readonly Dictionary<string, Func<IEnvironment>>
        _environments = FactoryHelpers.CreateEnvironmentDictionary();*/
    
    private readonly Dictionary<EnvironmentType, Func<IEnvironment>>
        _environments = FactoryHelpers.CreateEnvironmentDictionary();
    
    /*public IEnvironment Create(string environmentType)
    {
        if(!_environments.TryGetValue(environmentType, out var environment))
            throw new ArgumentException($"Unknown environment type: {environmentType}");
        
        return environment();
    }*/
    
    public IEnvironment Create(EnvironmentType environmentType)
    {
        if(!_environments.TryGetValue(environmentType, out var environment))
            throw new ArgumentException($"Unknown environment type: {environmentType}");
        
        return environment();
    }

    public IEnumerable<IEnvironmentDisplayModel> GetRegisteredEnvironments()
    {
        return _environments.Keys.Select(key => new EnvironmentDisplayModel
        {
            Type = key,
            Name = key.ToString(),
        });
    }
}