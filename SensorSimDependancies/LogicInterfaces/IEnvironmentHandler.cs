namespace SensorSimDependancies.LogicInterfaces;

public interface IEnvironmentHandler
{
    public void Update();
    public string GetEnvironmentColor();
    public void GetActiveEnvironment();
    public void SetActiveEnvironment();
}