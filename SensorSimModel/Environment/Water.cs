namespace SensorSimModel.Environment;

public abstract class Water() : EnvironmentBase("blue")
{
    public double Depth { get; set; }
    public double Pressure { get; set; }
}

