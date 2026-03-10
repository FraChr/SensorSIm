using SensorSimModel.Interfaces;

namespace SensorSimLogic.Interfaces;

public interface ISensorHandler
{
    public List<ISensorDisplayModel> RefreshAll();
    public ISensor CreateSensor(string sensorType);
    public IEnumerable<ISensorDisplayModel> GetAvailableSensors();
}