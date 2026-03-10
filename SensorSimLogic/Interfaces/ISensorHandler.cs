using SensorSimModel;
using SensorSimModel.Interfaces;

namespace SensorSimLogic.Interfaces;

public interface ISensorHandler
{
    public List<ISensorDisplayModel> RefreshAll();
    public ISensor CreateSensor(SensorTypes sensorType);
    public IEnumerable<ISensorDisplayModel> GetAvailableSensors();
}