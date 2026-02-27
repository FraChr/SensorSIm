using SensorSimDependancies.LogicInterfaces;
using SensorSimModel.Sensor;

namespace SensorSimLogic;

public class SensorFactory : ISensorFactory
{
    private readonly Dictionary<string, Func<ISensorLogic>> _creators;

    public SensorFactory()
    {
        _creators = new()
        {
            {"Temperature", () => new TempSensor()},
            {"Pressure", () => new  PressureSensor()}
        };
    }
    
    public ISensorLogic Create(string sensorType)
    {
        if (!_creators.TryGetValue(sensorType, out var creator))
            throw new ArgumentException($"Sensor type '{sensorType}' not registered.");
        
        return creator();
    }

    public IEnumerable<ISensorDisplayModel> GetAvailableSensors()
    {
        /*return _creators.Keys;*/

        return _creators.Keys.Select(key => new SensorDisplayModel(key)
        {
            Name = key,
        });
    }
}