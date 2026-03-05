using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimLogic;

public class EnvironmentHandler : IEnvironmentHandler
{
    private readonly IEnvironmentFactory _environmentFactory;
    private IEnvironment _activeEnvironment;
    
    public EnvironmentHandler(IEnvironmentFactory environmentFactory)
    {
        _environmentFactory = environmentFactory;
        _activeEnvironment = _environmentFactory.Create("Ocean");
    }
    
    public void Update()
    {
        _activeEnvironment.Update();
    }

    public string GetEnvironmentColor()
    {
        return _activeEnvironment.EnvironmentColor;
    }

    public void SetActiveEnvironment(string environmentType)
    {
        _activeEnvironment = _environmentFactory.Create(environmentType);
    }
    public IEnvironment GetActiveEnvironment()
    {
        return _activeEnvironment;
    }
}