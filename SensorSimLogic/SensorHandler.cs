using SensorSimLogic.Interfaces;
using SensorSimModel;
using SensorSimModel.Interfaces;
using SensorSimModel.UI.Sensor;

namespace SensorSimLogic;

public class SensorHandler : ISensorHandler
{
    private readonly List<ActiveSensor> _activeSensors = [];
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
            sensor.Sensor.UpdateFromEnvironment(environment);
            sensor.Sensor.UpdateValue(sensor.Display);
            result.Add(sensor.Display);
        }
        
        return result;
    }

    public ISensorDisplayModel GetDisplayForSensor(ISensor sensor)
    {
        var active = _activeSensors.FirstOrDefault(s => s.Sensor == sensor);
        if(active == null)
            throw new InvalidOperationException("sensor not found");
        
        return active.Display;
    }
    public ISensor CreateSensor(SensorTypes sensorType)
    {
        var sensor = _sensorFactory.Create(sensorType);
        _activeSensors.Add(new ActiveSensor(sensor, sensor.ToDisplayModel()));
        return sensor;
    }

    public void RemoveInvalidSensors(IEnumerable<SensorTypes> validTypes)
    {
        _activeSensors.RemoveAll(sensor => !validTypes.Contains(sensor.Display.Type));
    }
    
    public IEnumerable<ISensorDisplayModel> GetAvailableSensors()
    {
        var available = _sensorFactory.GetRegisteredSensors();
        var env = _environmentHandler.GetActiveEnvironment();
        var envType = env.GetType();
        
        
        
        return available
            .Where(kvp => kvp.Value.MetaData.Any(meta => meta.IsAssignableFrom(envType)))
            .Select(kvp => new SensorDisplayModel(kvp.Key.ToString())
            {
                Type = kvp.Key,
                Name = kvp.Key.ToString(),
                SensorImage = new ImageModel(kvp.Value.DefaultImagePath)
            });
    }
}