using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;
using SensorSimModel.Environment.DesertEnvironments;
using SensorSimModel.Environment.WaterEnvironments;
using SensorSimModel.Sensor;

namespace SensorSimUtility;

public static class FactoryHelpers
{
    public static Dictionary<string, Func<ISensor>> CreateSensorDictionary()
    {
        var sensorsFactory = new  Dictionary<string, Func<ISensor>>
        {
            {"Temperature", () => new TempSensor()},
            {"Pressure", () => new  PressureSensor()},
            {"Depth", () => new  DeapthSensor()},
            {"Salinity", () => new SalinitySensor()},
        };
        return sensorsFactory;
    }

    public static Dictionary<string, Func<IEnvironment>> CreateEnvironmentDictionary()
    {
        var environmentFactory = new Dictionary<string, Func<IEnvironment>>
        {
            { "Ocean", () => new Ocean() },
            { "Lake", () => new Lake() },
            { "SandDesert", () => new SandDesert() }
        };
        return environmentFactory;
    }
}