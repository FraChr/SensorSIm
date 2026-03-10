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
    private readonly Dictionary<EnvironmentTypes, Func<IEnvironment>>
        _environments = FactoryHelpers.CreateEnvironmentDictionary();
    public IEnvironment Create(EnvironmentTypes environmentTypes)
    {
        if(!_environments.TryGetValue(environmentTypes, out var environment))
            throw new ArgumentException($"Unknown environment type: {environmentTypes}");
        
        return environment();
    }

    public IEnumerable<IEnvironmentDisplayModel> GetRegisteredEnvironments()
    {
        return _environments.Keys.Select(key => new EnvironmentDisplayModel
        {
            Types = key,
            Name = key.ToString(),
        });
    }
}