using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;
using SensorSimModel.Sensor;

namespace SensorSimLogic;


// TODO: Responsible for creating, updating and general logical handling of sensors
// should also give view model in ui data needed to display a sensor
public class SensorHandler : ISensorHandler
{
    private readonly List<ISensorLogic> _activeSensors = new();
    private readonly IOcean _ocean;
    private readonly ISensorFactory _sensorFactory;

    public SensorHandler(IOcean ocean, ISensorFactory sensorFactory)
    {
        _ocean = ocean;
        _sensorFactory = sensorFactory;
    }
    
    public List<ISensorDisplayModel> RefreshAll()
    {
        var result = new List<ISensorDisplayModel>();

        foreach (var sensor in _activeSensors)
        {
            var value = sensor.GetEnvironmentValue(_ocean);
            sensor.Update(value);
            result.Add(sensor.ToDisplayModel());
        }
        
        return result;
    }

    public ISensorLogic CreateSensor(string sensorType)
    {
        var sensor = _sensorFactory.Create(sensorType);
        _activeSensors.Add(sensor);
        return sensor;
    }
}