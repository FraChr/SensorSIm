using SensorSimDependancies.LogicInterfaces;
using SensorSimModel.Sensor;

namespace SensorSimLogic;

public class SensorFactory : ISensorFactory
{
    private readonly Dictionary<string, Func<ISensor>> _creators;

    public SensorFactory()
    {
        _creators = new()
        {
            {"Temperature", () => new TempSensor()},
            {"Pressure", () => new  PressureSensor()},
            {"Depth", () => new  DeapthSensor()},
            {"Salinity", () => new SalinitySensor()},
        };
    }
    
    public ISensor Create(string sensorType)
    {
        if (!_creators.TryGetValue(sensorType, out var creator))
            throw new ArgumentException($"Sensor type '{sensorType}' not registered.");
        
        return creator();
    }

    public IEnumerable<ISensorDisplayModel> GetRegisteredSensors()
    {
        return _creators.Keys.Select(key => new SensorDisplayModel(key)
        {
            Name = key,
        });
    }
}