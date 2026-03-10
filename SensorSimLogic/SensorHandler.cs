using SensorSimLogic.Interfaces;
using SensorSimModel;
using SensorSimModel.Interfaces;
using SensorSimModel.Sensor;

namespace SensorSimLogic;
public class SensorHandler : ISensorHandler
{
    private readonly List<ISensor> _activeSensors = [];
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
    public ISensor CreateSensor(SensorTypes sensorType)
    {
        var sensor = _sensorFactory.Create(sensorType);
        _activeSensors.Add(sensor);
        return sensor;
    }

    public void RemoveInvalidSensors(IEnumerable<SensorTypes> validTypes)
    {
        _activeSensors.RemoveAll(sensor => !validTypes.Contains(sensor.ToDisplayModel().Type));
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
                Name = kvp.Key.ToString()
            });
    }
}