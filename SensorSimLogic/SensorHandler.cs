using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;

namespace SensorSimLogic;


// TODO: Responsible for creating, updating and general logical handling of sensors
// should also give view model in ui data needed to display a sensor
public class SensorHandler : ISensorHandler
{
    private readonly List<ISensor> _activeSensors = new();
    private readonly ISensorFactory _sensorFactory;
    private readonly IEnvironmentHandler _environmentHandler;

    public SensorHandler(ISensorFactory sensorFactory, IEnvironmentHandler environmentHandler)
    {
        _sensorFactory = sensorFactory;
        _environmentHandler = environmentHandler;
    }
    
    public List<ISensorDisplayModel> RefreshAll()
    {
        var result = new List<ISensorDisplayModel>();

        var environment = _environmentHandler.GetActiveEnvironment();
        
        foreach (var sensor in _activeSensors)
        {
            sensor.UpdateFromEnvironment(environment);
            result.Add(sensor.ToDisplayModel());
        }
        
        return result;
    }

    public ISensor CreateSensor(string sensorType)
    {
        var sensor = _sensorFactory.Create(sensorType);
        _activeSensors.Add(sensor);
        return sensor;
    }
}