namespace SensorSimModel.Interfaces;

public interface IOcean : IWater
{
    public double Salinity { get; set; }
}