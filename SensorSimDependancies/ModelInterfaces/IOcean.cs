namespace SensorSimDependancies.ModelInterfaces;

public interface IOcean
{
    public double SaltLevel { get; set; }
    public double Deapth { get; set; }
    public string EnvrionmentColor { get; set; }
    public double Temperatures { get; set; }
}