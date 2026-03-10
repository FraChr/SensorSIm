using SensorSimModel.Interfaces;

namespace SensorSimLogic.Interfaces;

public interface ISensorFactory
{
    ISensor Create(string sensorType);
    IEnumerable<ISensorDisplayModel> GetRegisteredSensors();
}