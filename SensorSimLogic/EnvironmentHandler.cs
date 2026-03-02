using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimLogic;

public class EnvironmentHandler : IEnvironmentHandler
{
    private IOcean _ocean;
    private Dictionary<string, Type> _environmentMap;
    
    public EnvironmentHandler(IOcean ocean)
    {
        _ocean = ocean;

        _environmentMap = new()
        {
            {"ocean", typeof(IOcean)}
        };

    }
    
    public void Update()
    {
        _ocean.Update();
    }

    public string GetEnvironmentColor()
    {
        return _ocean.EnvironmentColor;
    }

    public void SetActiveEnvironment()
    {
        
    }
    public void GetActiveEnvironment()
    {
        
    }
}