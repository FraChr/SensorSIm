namespace SensorSimModel.Interfaces;

public interface IEnvironment
{
    public string EnvironmentColor { get; set; }
    public double Temperatures { get; set; }
    public IEnvironmentDisplayModel ToDisplayModel();
    public void Update();
    public ImageModel Image { get; set; }
}