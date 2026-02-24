using SensorSimDependancies.LogicInterfaces;

namespace SensorSimModel.Sensor;

public class TempSensor : SensorBase, ITemperature, ISensorLogic
{
    public string Name { get; set; } = "TempSensor";
    public double Temperature { get; set; }
    public byte[] Image { get; set; }
    
    public void Update(double temp)
    {
        /*Temperature = ReadTempFromHW(temp);*/
        Temperature = temp;
    }

    public ISensorDisplayModel ToDisplayModel()
    {
        return new SensorDisplayModel()
        {
            Name = Name,
            Temperature = $"{Temperature} C"
        };
   }

    private double ReadTempFromHW(double temp)
    {
        var nTemp = temp + 1;
        return nTemp;
    }
}
