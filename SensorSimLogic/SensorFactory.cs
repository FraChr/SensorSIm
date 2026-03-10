using SensorSimLogic.Interfaces;
using SensorSimModel;
using SensorSimModel.Interfaces;
using SensorSimModel.Sensor;
using SensorSimUtility;

namespace SensorSimLogic;

public class SensorFactory : ISensorFactory
{
    private readonly Dictionary<SensorTypes, Func<ISensor>> _sensors = FactoryHelpers.CreateSensorDictionary();
    public ISensor Create(SensorTypes sensorType)
    {
        if (!_sensors.TryGetValue(sensorType, out var creator))
            throw new ArgumentException($"Sensor type '{sensorType}' not registered.");
        
        return creator();
    }

    public IEnumerable<ISensorDisplayModel> GetRegisteredSensors()
    {
        return _sensors.Keys.Select(key => new SensorDisplayModel(key.ToString())
        {
            Type = key,
            Name = key.ToString()
        });
    }
}