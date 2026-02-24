using SensorSimDependancies.LogicInterfaces;
using SensorSimDependancies.ModelInterfaces;
using SensorSimModel.Sensor;

namespace SensorSimLogic;


// TODO: Responsible for creating, updating and general logical handling of sensors
// should also give view model in ui data needed to display a sensor
public class SensorHandler : ISensorHandler
{
    private readonly List<ISensorLogic> _sensors = new();
    private readonly IOcean _ocean;

    public SensorHandler(IOcean ocean)
    {
        _ocean = ocean;
    }
    
    public List<ISensorDisplayModel> RefreshAll()
    {
        var result = new List<ISensorDisplayModel>();

        foreach (var sensor in _sensors)
        {
            sensor.Update(_ocean.Temperatures);
            result.Add(sensor.ToDisplayModel());
        }
        
        return result;
    }

    public void CreateSensor()
    {
        _sensors.Add(new TempSensor());
    }
}