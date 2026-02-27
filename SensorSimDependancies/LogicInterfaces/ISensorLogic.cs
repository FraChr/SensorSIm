using SensorSimDependancies.ModelInterfaces;

namespace SensorSimDependancies.LogicInterfaces;

public interface ISensorLogic
{
    string SensorType { get; }
    public void Update(double value);
    ISensorDisplayModel ToDisplayModel();
    
    Func<IOcean, double> GetEnvironmentValue { get; }
}