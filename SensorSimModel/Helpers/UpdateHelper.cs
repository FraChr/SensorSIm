namespace SensorSimModel.Helpers;

public static class UpdateHelper
{
    private static readonly Random Random = new();
    public static double TempCalc(double currentTemp)
    {
        var change = Random.Next(-1, 2);
        return currentTemp + change;
    }
}