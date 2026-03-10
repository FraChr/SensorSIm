using SensorSimModel;
using SensorSimModel.Environment.DesertEnvironments;
using SensorSimModel.Environment.WaterEnvironments;
using SensorSimModel.Interfaces;
using SensorSimModel.Sensor;

namespace SensorSimUtility;

public static class FactoryHelpers
{ 
    public static Dictionary<SensorTypes, Func<ISensor>> CreateSensorDictionary()
    {
        var sensorsFactory = new  Dictionary<SensorTypes, Func<ISensor>>
        {
            {SensorTypes.Temperature, () => new TempSensor()},
            {SensorTypes.Pressure, () => new  PressureSensor()},
            {SensorTypes.Depth, () => new  DeapthSensor()},
            {SensorTypes.Salinity, () => new SalinitySensor()},
        };
        return sensorsFactory;
    }
    public static Dictionary<EnvironmentTypes, Func<IEnvironment>> CreateEnvironmentDictionary()
    {
        var environmentFactory = new Dictionary<EnvironmentTypes, Func<IEnvironment>>
        {
            { EnvironmentTypes.Ocean, () => new Ocean() },
            { EnvironmentTypes.Lake, () => new Lake() },
            { EnvironmentTypes.SandDesert, () => new SandDesert() }
        };
        return environmentFactory;
    }
}