using SensorSimModel;
using SensorSimModel.Interfaces;
using SensorSimUtility;

namespace SensorSimLogic.Interfaces;

public interface ISensorFactory
{
    ISensor Create(SensorTypes sensorType);
    Dictionary<SensorTypes, FactoryRegistration> GetRegisteredSensors();
}