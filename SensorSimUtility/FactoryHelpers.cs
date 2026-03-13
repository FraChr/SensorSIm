using System.Data.Common;
using Resources;
using SensorSimModel;
using SensorSimModel.Environment;
using SensorSimModel.Environment.DesertEnvironments;
using SensorSimModel.Environment.WaterEnvironments;
using SensorSimModel.Interfaces;
using SensorSimModel.Sensor;

namespace SensorSimUtility;

public static class FactoryHelpers
{ 
    public static Dictionary<SensorTypes, FactoryRegistration> CreateSensorDictionary()
    {
        var sensorsFactory = new  Dictionary<SensorTypes, FactoryRegistration>
        {
            {
                SensorTypes.Temperature, new FactoryRegistration
                {
                    FactoryFunc = () => new TempSensor(),
                    MetaData = [typeof(EnvironmentBase)],
                    DefaultImagePath = SensorImagePaths.TempSensorImg
                }
            },
            {
                SensorTypes.Pressure, new FactoryRegistration
                {
                    FactoryFunc = () => new PressureSensor(),
                    MetaData = [typeof(Water), typeof(IAir)]
                }
            },
            {
                SensorTypes.Depth, new FactoryRegistration
                {
                    FactoryFunc = () => new DeapthSensor(),
                    MetaData = [typeof(Water)]
                }
            },
            {
                SensorTypes.Salinity,  new FactoryRegistration
                {
                    FactoryFunc = () => new SalinitySensor(),
                    MetaData = [typeof(Ocean)]
                }
            }
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