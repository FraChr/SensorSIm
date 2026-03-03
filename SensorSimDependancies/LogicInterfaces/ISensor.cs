using SensorSimDependancies.ModelInterfaces;

namespace SensorSimDependancies.LogicInterfaces;

public interface ISensor
{
    public void Update(double value);
    ISensorDisplayModel ToDisplayModel();
    
    Func<IEnvironment, double> GetEnvironmentValue { get; }
}