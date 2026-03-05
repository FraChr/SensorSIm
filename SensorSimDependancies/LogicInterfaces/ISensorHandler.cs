namespace SensorSimDependancies.LogicInterfaces;

public interface ISensorHandler
{
    public List<ISensorDisplayModel> RefreshAll();
    public ISensor CreateSensor(string sensorType);
    public IEnumerable<ISensorDisplayModel> GetAvailableSensors();
}