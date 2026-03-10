using SensorSimLogic.Interfaces;
using SensorSimModel;
using SensorSimModel.Interfaces;

namespace SensorSimLogic;

public class EnvironmentHandler : IEnvironmentHandler
{
    private readonly IEnvironmentFactory _environmentFactory;
    private IEnvironment _activeEnvironment;
    
    public EnvironmentHandler(IEnvironmentFactory environmentFactory)
    {
        _environmentFactory = environmentFactory;
        _activeEnvironment = _environmentFactory.Create(EnvironmentTypes.Ocean);
    }
    
    public void EnvUpdate()
    {
        _activeEnvironment.Update();
    }

    public string GetEnvironmentColor()
    {
        return _activeEnvironment.EnvironmentColor;
    }
    public void SetActiveEnvironment(EnvironmentTypes environmentTypes)
    {
        _activeEnvironment = _environmentFactory.Create(environmentTypes);
    }
    public IEnvironment GetActiveEnvironment()
    {
        return _activeEnvironment;
    }

    public IEnumerable<IEnvironmentDisplayModel> GetAvailableEnvironments()
    {
        return _environmentFactory.GetRegisteredEnvironments();
    }
}