using SensorSimModel;
using SensorSimModel.Interfaces;

namespace SensorSimLogic.Interfaces;

public interface ISensorFactory
{
    ISensor Create(SensorTypes sensorType);
    IEnumerable<ISensorDisplayModel> GetRegisteredSensors();
}