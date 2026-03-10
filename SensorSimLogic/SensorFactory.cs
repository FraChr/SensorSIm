using SensorSimLogic.Interfaces;
using SensorSimModel.Interfaces;
using SensorSimModel.Sensor;
using SensorSimUtility;

namespace SensorSimLogic;

public class SensorFactory : ISensorFactory
{
    private readonly Dictionary<string, Func<ISensor>> _sensors = FactoryHelpers.CreateSensorDictionary();
    public ISensor Create(string sensorType)
    {
        if (!_sensors.TryGetValue(sensorType, out var creator))
            throw new ArgumentException($"Sensor type '{sensorType}' not registered.");
        
        return creator();
    }

    public IEnumerable<ISensorDisplayModel> GetRegisteredSensors()
    {
        return _sensors.Keys.Select(key => new SensorDisplayModel(key)
        {
            Name = key,
        });
    }
}