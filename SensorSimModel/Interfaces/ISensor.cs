namespace SensorSimModel.Interfaces;

public interface ISensor
{
    ISensorDisplayModel ToDisplayModel();
    void UpdateFromEnvironment(IEnvironment environment);
    
}