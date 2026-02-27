namespace SensorSimDependancies.LogicInterfaces;

public interface ISensorHandler
{
    public List<ISensorDisplayModel> RefreshAll();
    public ISensorLogic CreateSensor(string sensorType);
}