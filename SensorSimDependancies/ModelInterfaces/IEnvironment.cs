using SensorSimDependancies.LogicInterfaces;

namespace SensorSimDependancies.ModelInterfaces;

public interface IEnvironment
{
    public string EnvironmentColor { get; set; }
    public double Temperatures { get; set; }
    
    public double Depth { get; set; }
    public double Pressure { get; set; }
    
    public IEnvironmentDisplayModel ToDisplayModel();
    public void Update();
}