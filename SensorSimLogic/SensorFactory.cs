using SensorSimLogic.Interfaces;
using SensorSimModel;
using SensorSimModel.Interfaces;
using SensorSimModel.Sensor;
using SensorSimUtility;

namespace SensorSimLogic;

public class SensorFactory : ISensorFactory
{
    private readonly Dictionary<SensorTypes, FactoryRegistration> _sensors = FactoryHelpers.CreateSensorDictionary();
    public ISensor Create(SensorTypes sensorType)
    {
        if (!_sensors.TryGetValue(sensorType, out var creator))
            throw new ArgumentException($"Sensor type '{sensorType}' not registered.");
        
        return creator.EnvironmentFactory();
    }
    
    public Dictionary<SensorTypes, FactoryRegistration> GetRegisteredSensors()
    {
        return _sensors;
    }
    
}