using SensorSimDependancies.ModelInterfaces;

namespace SensorSimModel.Environment;

public abstract class EnvironmentBase
{
    public string EnvironmentColor { get; set; }
    public double Temperatures { get; set; }

    public EnvironmentBase(string environmentColor)
    {
        EnvironmentColor = environmentColor;
    }
}