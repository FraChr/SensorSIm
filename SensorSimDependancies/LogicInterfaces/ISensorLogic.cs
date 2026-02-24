namespace SensorSimDependancies.LogicInterfaces;

public interface ISensorLogic
{
    public void Update(double temp);
    ISensorDisplayModel ToDisplayModel();
}