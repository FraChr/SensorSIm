using SensorSimLogic.Interfaces;
using SensorSimModel;
using SensorSimModel.Interfaces;
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
    
    public Dictionary<SensorTypes, FactoryRegistrationDto> GetRegisteredSensors()
    {
        return _sensors
            .ToDictionary(kvp => kvp.Key,
                kvp => new FactoryRegistrationDto
                {
                    MetaData = kvp.Value.MetaData
                });
    }
}