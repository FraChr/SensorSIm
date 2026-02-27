namespace SensorSimDependancies.LogicInterfaces;

public interface ISensorFactory
{
    ISensorLogic Create(string sensorType);
    IEnumerable<ISensorDisplayModel> GetAvailableSensors();
}