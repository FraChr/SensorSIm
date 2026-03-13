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
                    EnvironmentFactory = () => new TempSensor(),
                    MetaData = [typeof(EnvironmentBase)],
                    DefaultImagePath = SensorImagePaths.TempSensorImg
                }
            },
            {
                SensorTypes.Pressure, new FactoryRegistration
                {
                    EnvironmentFactory = () => new PressureSensor(),
                    MetaData = [typeof(Water), typeof(IAir)]
                }
            },
            {
                SensorTypes.Depth, new FactoryRegistration
                {
                    EnvironmentFactory = () => new DeapthSensor(),
                    MetaData = [typeof(Water)]
                }
            },
            {
                SensorTypes.Salinity,  new FactoryRegistration
                {
                    EnvironmentFactory = () => new SalinitySensor(),
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