namespace SensorSimDependancies.ModelInterfaces;

public interface IOcean : IWater
{
    public double SaltLevel { get; set; }
    public void Update();
}