namespace SensorSimDependancies.LogicInterfaces;

public interface ISensorFactory
{
    ISensor Create(string sensorType);
    IEnumerable<ISensorDisplayModel> GetAvailableSensors();
}