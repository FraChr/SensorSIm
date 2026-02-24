namespace SensorSimDependancies.ModelInterfaces;

public interface IOcean : IWater
{
    public double SaltLevel { get; set; }
    public double Depth { get; set; }
    public string EnvironmentColor { get; set; }
    /*public double Temperatures { get; set; }*/
    public void Update();
}